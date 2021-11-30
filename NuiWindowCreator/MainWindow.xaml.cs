using NuiWindowCreator.NuiElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                "NuiList", "NuiListTemplateCell", "NuiColorPicker", "NuiOptions"
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
            var menuRemove = new MenuItem { Header = "Удалить" };
            menuRemove.Click += MenuRemove_Click; ;
            contextMenu.Items.Add(menuRemove);
        }

        private void MenuRemove_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuPack_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuAdd_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedElement == null)
                return;

            if (!(SelectedElement.NuiElement is NuiWindow || selectedElement.NuiElement is IHaveChildrens))
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
                ((IHaveChildrens)SelectedElement.NuiElement).AddChildren(element);
                AddNode(SelectedElement, element);
            }
        }

        private void AddNode(CustomTreeViewItem selectedElement, NuiElement element)
        {
            selectedElement.Items.Add(new CustomTreeViewItem { Header = element.GetType().Name, ContextMenu = contextMenu, NuiElement = element });
            selectedElement.IsExpanded = true;
            SignalChanged(nameof(Elements));
        }

        private void OnElementSelect(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedElement = e.NewValue as CustomTreeViewItem;
        }
    }
}
