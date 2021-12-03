using Microsoft.Win32;
using NuiWindowCreator.NuiElements;
using NuiWindowCreator.NuiProperties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace NuiWindowCreator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        static ContextMenu contextMenu = new ContextMenu();
        static ContextMenu contextMenuSmall = new ContextMenu();
        public string Json {
            get => json;
            set
            {
                json = value;
                SignalChanged();
            }
        }
        public List<CustomTreeViewItem> Elements { get; set; } = new List<CustomTreeViewItem>();

        private CustomTreeViewItem selectedElement;
        public CustomTreeViewItem SelectedElement
        {
            get => selectedElement;
            set
            {
                selectedElement = value;
                SignalChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        NuiWindow nui = new NuiWindow();
        private string json;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            InitContextMenu();
            Elements.Add(new CustomTreeViewItem { Header = nui.GetType().Name, ContextMenu = contextMenu, NuiElement = nui });
        }

        private void InitContextMenu()
        {
            var menuAdd = new MenuItem { Header = "Добавить" };

            var variants = new string[] { "NuiCol", "NuiRow", "NuiGroup",
                "NuiSpacer", "NuiLabel", "NuiText", "NuiButton", "NuiButtonImage", "NuiButtonSelect",
                "NuiCheck", "NuiImage" , "NuiCombo", "NuiSlider","NuiProgress","NuiTextEdit",
                "NuiList", "NuiColorPicker", "NuiOptions"
            };

            foreach (var v in variants)
            {
                var menu = new MenuItem { Header = v };
                menu.Click += MenuAdd_Click;
                menuAdd.Items.Add(menu);
            }

            contextMenu.Items.Add(menuAdd);
            menuAdd = new MenuItem { Header = "Упаковать в" };
            variants = new string[] { "NuiCol", "NuiRow", "NuiGroup" };
            foreach (var v in variants)
            {
                var menu = new MenuItem { Header = v };
                menu.Click += MenuPack_Click;
                menuAdd.Items.Add(menu);
            }
            contextMenu.Items.Add(menuAdd);
            menuAdd = new MenuItem { Header = "Упаковать в" };
            variants = new string[] { "NuiCol", "NuiRow", "NuiGroup" };
            foreach (var v in variants)
            {
                var menu = new MenuItem { Header = v };
                menu.Click += MenuPack_Click;
                menuAdd.Items.Add(menu);
            }
            contextMenuSmall.Items.Add(menuAdd);
            var menuRemove = new MenuItem { Header = "Удалить" };
            menuRemove.Click += MenuRemove_Click;
            contextMenu.Items.Add(menuRemove);
            menuRemove = new MenuItem { Header = "Удалить" };
            menuRemove.Click += MenuRemove_Click;
            contextMenuSmall.Items.Add(menuRemove);
        }

        private void MenuRemove_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedElement == null)
                return;
            if (SelectedElement.NuiElement is NuiWindow)
                return;

            var child = SelectedElement;
            var parent = (CustomTreeViewItem)SelectedElement.Parent;
            parent.Items.Remove(child);

            if (parent.NuiElement is NuiWindow window)
                window.root = new NullElement();
            else if (parent.NuiElement is NuiList list)
                list.RemoveTemplateCell(child.NuiElement);
            else
                ((IHaveChildrens)parent.NuiElement).RemoveChildren(child.NuiElement);
        }

        private void MenuPack_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedElement == null)
                return;
            if (SelectedElement.NuiElement is NuiWindow)
                return;

            string elementName = ((MenuItem)e.Source).Header.ToString();
            IHaveChildrens element = Nui.GetElementByName(elementName) as IHaveChildrens;
            if (element == null)
                return;

            var child = SelectedElement;
            element.AddChildren(child.NuiElement);

            var parent = (CustomTreeViewItem)SelectedElement.Parent;

            if (parent.NuiElement is NuiWindow window)
                window.root = element;
            else if (parent.NuiElement is NuiList list)
                list.ReplaceTemplateCell(child.NuiElement, element);
            else
                ((IHaveChildrens)parent.NuiElement).ReplaceChildren(child.NuiElement, element);
            var index = parent.Items.IndexOf(child);
            var node = new CustomTreeViewItem { 
                Header = element.GetType().Name, 
                ContextMenu = contextMenu, 
                NuiElement = element, 
                IsExpanded = true };
            parent.Items[index] = node;
            node.Items.Add(child);
            child.IsExpanded = true;
            SignalChanged(nameof(Elements));
        }

        private void MenuAdd_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedElement == null)
                return;

            if (!(SelectedElement.NuiElement is NuiWindow ||
                SelectedElement.NuiElement is NuiList || selectedElement.NuiElement is IHaveChildrens))
                return;

            string elementName = ((MenuItem)e.Source).Header.ToString();
            NuiElement element = Nui.GetElementByName(elementName);
            if (element == null)
                return;

            if (SelectedElement.NuiElement is NuiWindow window)
            {
                if (!(window.root is NullElement))
                    return;
                window.root = element;
                if (SelectedElement.Items.Count > 0)
                    SelectedElement.Items.Clear();
                AddNode(SelectedElement, element);
            }
            else
            {
                if (SelectedElement.NuiElement is NuiList list)
                    list.AddTemplateCell(element);
                else if (!((IHaveChildrens)SelectedElement.NuiElement).AddChildren(element))
                    return;
                AddNode(SelectedElement, element);
            }
        }

        private void AddNode(CustomTreeViewItem selectedElement, INui element)
        {
            var node = new CustomTreeViewItem {
                Header = element.GetType().Name, 
                ContextMenu = element is IHaveChildrens || element is NuiList ? contextMenu : contextMenuSmall, 
                NuiElement = element, 
                IsExpanded = true };
            selectedElement.Items.Add(node);
            selectedElement.IsExpanded = true;
            SignalChanged(nameof(Elements));
        }

        private void OnElementSelect(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedElement = e.NewValue as CustomTreeViewItem;
        }

        private void ClickShowJson(object sender, RoutedEventArgs e)
        {
            Json = Nui.GetJsonFromWindow((NuiWindow)Elements.First().NuiElement);
        }

        private void ClickCopyJson(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Json);
        }

        private void ClickSaveJson(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "resref.jui";
            sfd.Filter = "nwn json files|*.jui|All files|*.*";
            if (sfd.ShowDialog() == true)
                File.WriteAllText(sfd.FileName, Json);
        }

        private void buttonClearFloatValue(object sender, RoutedEventArgs e)
        {
            NuiSimpleProperty<float?> property = (NuiSimpleProperty<float?>)((Button)sender).Tag;
            property.Value = null;
        }

        private void buttonClearBoolValue(object sender, RoutedEventArgs e)
        {
            NuiBindBoolNullableProperty property = (NuiBindBoolNullableProperty)((Button)sender).Tag;
            property.Value = null;
        }

        private void editCombo(object sender, RoutedEventArgs e)
        {
            var targetProp = ((MenuItem)sender).Tag;
            WinListStringEdit win;
            if (targetProp is NuiComboItemsSelectProperty prop)
            {
                win = new WinListStringEdit(prop.Values);
                if (win.ShowDialog() == true)
                {
                    prop.Values = new ObservableCollection<StringEntry>(win.Values);
                }
            }
            else if (targetProp is NuiArrayItemsSelectProperty propArray)
            {
                win = new WinListStringEdit(propArray.Values);
                if (win.ShowDialog() == true)
                {
                    propArray.Values = new ObservableCollection<StringEntry>(win.Values);
                }
            }
        }
    }
}
