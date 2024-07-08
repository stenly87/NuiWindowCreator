using Microsoft.Win32;
using Newtonsoft.Json;
using NuiWindowCreator.NuiElements;
using NuiWindowCreator.NuiProperties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
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
        static ContextMenu contextMenuChart = new ContextMenu();
        static ContextMenu contextMenuChartSlot = new ContextMenu();
        public string Json
        {
            get => json;
            set
            {
                json = value;
                SignalChanged();
            }
        }

        public string Binds
        {
            get => binds;
            set
            {
                binds = value;
                SignalChanged();
            }
        }
        public ObservableCollection<CustomTreeViewItem> Elements { get; set; } = new ObservableCollection<CustomTreeViewItem>();

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
        private string binds;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            InitContextMenu();
            Elements.Add(new CustomTreeViewItem { Header = nui.GetType().Name, ContextMenu = contextMenu, NuiElement = nui });
        }

        private void InitContextMenu()
        {
            var menuAdd = new MenuItem { Header = "Add Nui element" };

            var variants = new string[] { "NuiCol", "NuiRow", "NuiGroup",
                "NuiSpacer", "NuiLabel", "NuiText", "NuiButton", "NuiButtonImage", "NuiButtonSelect",
                "NuiCheck", "NuiImage" , "NuiCombo", "NuiSlider","NuiSliderFloat","NuiProgress","NuiTextEdit",
                "NuiList", "NuiColorPicker", "NuiOptions", "NuiToggles", "NuiChart"
            };

            foreach (var v in variants)
            {
                var menu = new MenuItem { Header = v };
                menu.Click += MenuAdd_Click;
                menuAdd.Items.Add(menu);
            }

            contextMenu.Items.Add(menuAdd);
            menuAdd = new MenuItem { Header = "Add Draw element" };
            variants = new string[] { "NuiDrawListPolyLine", "NuiDrawListCurve", "NuiDrawListCircle", "NuiDrawListArc", "NuiDrawListText", "NuiDrawListImage" };
            foreach (var v in variants)
            {
                var menu = new MenuItem { Header = v };
                menu.Click += MenuAddDraw_Click;
                menuAdd.Items.Add(menu);
            }
            contextMenu.Items.Add(menuAdd);
            menuAdd = new MenuItem { Header = "Add Draw element" };
            variants = new string[] { "NuiDrawListPolyLine", "NuiDrawListCurve", "NuiDrawListCircle", "NuiDrawListArc", "NuiDrawListText", "NuiDrawListImage" };
            foreach (var v in variants)
            {
                var menu = new MenuItem { Header = v };
                menu.Click += MenuAddDraw_Click;
                menuAdd.Items.Add(menu);
            }
            contextMenuSmall.Items.Add(menuAdd);

            menuAdd = new MenuItem { Header = "Pack to container" };
            variants = new string[] { "NuiCol", "NuiRow", "NuiGroup" };
            foreach (var v in variants)
            {
                var menu = new MenuItem { Header = v };
                menu.Click += MenuPack_Click;
                menuAdd.Items.Add(menu);
            }
            contextMenu.Items.Add(menuAdd);
            menuAdd = new MenuItem { Header = "Pack to container" };
            variants = new string[] { "NuiCol", "NuiRow", "NuiGroup" };
            foreach (var v in variants)
            {
                var menu = new MenuItem { Header = v };
                menu.Click += MenuPack_Click;
                menuAdd.Items.Add(menu);
            }
            contextMenuSmall.Items.Add(menuAdd);
            contextMenu.Items.Add(CreateMenuVisual());
            contextMenuSmall.Items.Add(CreateMenuVisual());

            var menuRemove = new MenuItem { Header = "Remove element" };
            menuRemove.Click += MenuRemove_Click;
            contextMenu.Items.Add(menuRemove);
            menuRemove = new MenuItem { Header = "Remove element" };
            menuRemove.Click += MenuRemove_Click;
            contextMenuSmall.Items.Add(menuRemove);

            var menuChart = new MenuItem { Header = "Add chart slot" };
            menuChart.Click += MenuAddChartSlot_Click;
            contextMenuChart.Items.Add(menuChart);
            menuAdd = new MenuItem { Header = "Pack to container" };
            variants = new string[] { "NuiCol", "NuiRow", "NuiGroup" };
            foreach (var v in variants)
            {
                var menu = new MenuItem { Header = v };
                menu.Click += MenuPack_Click;
                menuAdd.Items.Add(menu);
            }
            contextMenuChart.Items.Add(menuAdd);
            contextMenuChart.Items.Add(CreateMenuVisual());
            var menuChart2 = new MenuItem { Header = "Remove chart slot" };
            menuChart2.Click += MenuRemoveChartSlot_Click;
            contextMenuChartSlot.Items.Add(menuChart2);
        }

        private MenuItem CreateMenuVisual()
        {
            var menuItem = new MenuItem { Header = "Visual" };
            var menuMove = new MenuItem { Header = "Move up" };
            menuMove.Click += MenuMoveUp_Click;
            menuItem.Items.Add(menuMove);
            menuMove = new MenuItem { Header = "Move down" };
            menuMove.Click += MenuMoveDown_Click;
            menuItem.Items.Add(menuMove);
            menuMove = new MenuItem { Header = "Copy" };
            menuMove.Click += MenuCopy_Click;
            menuItem.Items.Add(menuMove);
            menuMove = new MenuItem { Header = "Cut" };
            menuMove.Click += MenuCut_Click;
            menuItem.Items.Add(menuMove);
            menuMove = new MenuItem { Header = "Paste" };
            menuMove.Click += MenuPaste_Click;
            menuItem.Items.Add(menuMove);
            return menuItem;
        }

        private void MenuPaste_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedElement == null)
                return;
            if (SelectedElement.NuiElement is NuiWindow || SelectedElement.NuiElement is NuiDrawListItem)
                return;
            if (paste == null)
                return;
            if (((CustomTreeViewItem)SelectedElement).NuiElement is IHaveChildrens parent)
                parent.AddChildren(paste.NuiElement);
            else if (((CustomTreeViewItem)SelectedElement.Parent).NuiElement is NuiList list)
                list.AddTemplateCell(paste.NuiElement);
            else
                return;
            SelectedElement.Items.Add(paste);
            paste = (CustomTreeViewItem)paste.Clone();
            ReloadTree();
        }
        CustomTreeViewItem paste;
        private void MenuCopy_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedElement == null)
                return;
            if (SelectedElement.NuiElement is NuiWindow || SelectedElement.NuiElement is NuiDrawListItem)
                return;

            paste = (CustomTreeViewItem)SelectedElement.Clone();
        }
        private void MenuCut_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedElement == null)
                return;
            if (SelectedElement.NuiElement is NuiWindow || SelectedElement.NuiElement is NuiDrawListItem)
                return;

            if (((CustomTreeViewItem)SelectedElement.Parent).NuiElement is IHaveChildrens parent)
                parent.RemoveChildren(SelectedElement.NuiElement);
            else if (((CustomTreeViewItem)SelectedElement.Parent).NuiElement is NuiList list)
                list.RemoveTemplateCell(SelectedElement.NuiElement);
            else
                return;
            paste = SelectedElement;
            ((CustomTreeViewItem)SelectedElement.Parent).Items.Remove(paste);
        }

        private void MenuMoveDown_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedElement == null)
                return;
            if (SelectedElement.NuiElement is NuiWindow || SelectedElement.NuiElement is NuiDrawListItem)
                return;
            var parent = ((CustomTreeViewItem)SelectedElement.Parent);
            var index = parent.Items.IndexOf(SelectedElement);
            if (index + 1 == parent.Items.Count)
                return;
            if (parent.NuiElement is IHaveChildrens parentNui)
                parentNui.MoveDownChildren(SelectedElement.NuiElement);
            else if (parent.NuiElement is NuiList list)
                list.MoveDownTemplateCell(SelectedElement.NuiElement);
            else
                return;
            index++;
            List<CustomTreeViewItem> tempArray = new List<CustomTreeViewItem>();
            foreach (var item in parent.Items)
                tempArray.Add((CustomTreeViewItem)item);
            var temp = tempArray[index];
            tempArray[index] = SelectedElement;
            tempArray[index - 1] = temp;
            parent.Items.Clear();
            foreach (var item in tempArray)
                parent.Items.Add(item);
        }

        private void MenuMoveUp_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedElement == null)
                return;
            if (SelectedElement.NuiElement is NuiWindow || SelectedElement.NuiElement is NuiDrawListItem)
                return;
            var parent = ((CustomTreeViewItem)SelectedElement.Parent);
            var index = parent.Items.IndexOf(SelectedElement);
            if (index == 0)
                return;
            if (parent.NuiElement is IHaveChildrens parentNui)
                parentNui.MoveUpChildren(SelectedElement.NuiElement);
            else if (parent.NuiElement is NuiList list)
                list.MoveUpTemplateCell(SelectedElement.NuiElement);
            else
                return;
            index--;
            List<CustomTreeViewItem> tempArray = new List<CustomTreeViewItem>();
            foreach (var item in parent.Items)
                tempArray.Add((CustomTreeViewItem)item);
            var temp = tempArray[index];
            tempArray[index] = SelectedElement;
            tempArray[index + 1] = temp;
            parent.Items.Clear();
            foreach (var item in tempArray)
                parent.Items.Add(item);
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

            if (child.NuiElement is NuiDrawListItem)
            {
                ((NuiElement)parent.NuiElement).RemoveDrawItem(child.NuiElement);
                return;
            }

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
            if (SelectedElement.NuiElement is NuiWindow || SelectedElement.NuiElement is NuiDrawListItem)
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
            var node = new CustomTreeViewItem
            {
                Header = element.GetType().Name,
                ContextMenu = contextMenu,
                NuiElement = element,
                IsExpanded = true
            };
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

        private void MenuAddDraw_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedElement == null)
                return;

            if (SelectedElement.NuiElement is NuiWindow)
                return;

            if (SelectedElement.NuiElement is NuiDrawListItem)
                return;

            string elementName = ((MenuItem)e.Source).Header.ToString();
            var element = Nui.GetiNuiElementByName(elementName);
            if (element == null)
                return;

            ((NuiElement)SelectedElement.NuiElement).AddDrawItem(element);

            AddNode(SelectedElement, element);
        }

        private void MenuRemoveChartSlot_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedElement.NuiElement is NuiChartSlot slot)
            {
                var parent = (CustomTreeViewItem)SelectedElement.Parent;

                if (parent.NuiElement is NuiChart chart)
                {
                    chart.RemoveChildren(SelectedElement.NuiElement);
                    parent.Items.Remove(SelectedElement);
                }
            }
        }

        private void MenuAddChartSlot_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedElement.NuiElement is NuiChart chart)
            {
                var slot = chart.AddChildren();
                AddNode(SelectedElement, slot);
            }
        }

        private CustomTreeViewItem AddNode(CustomTreeViewItem selectedElement, INui element)
        {
            var node = new CustomTreeViewItem
            {
                Header = element.GetType().Name,
                ContextMenu = element is NuiChartSlot ? contextMenuChartSlot : (element is NuiChart ? contextMenuChart :  (element is IHaveChildrens || element is NuiList ? contextMenu : contextMenuSmall)),
                NuiElement = element,
                IsExpanded = true
            };
            selectedElement.Items.Add(node);
            selectedElement.IsExpanded = true;
            SignalChanged(nameof(Elements));
            return node;
        }

        private void OnElementSelect(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedElement = e.NewValue as CustomTreeViewItem;
        }

        private void ClickShowJson(object sender, RoutedEventArgs e)
        {
            if (nui.edge_constraint is NuiGeometry g && g.IsZero())
                nui.edge_constraint = null;
            if (nui.size_constraint is NuiGeometry s && s.IsZero())
                nui.size_constraint = null;
            UpdateListTemplatesWidth(nui.root);
            Json = Nui.GetJsonFromWindow((NuiWindow)Elements.First().NuiElement);
            List<string> binds = new List<string>();
            SearchBinds(Elements.First(), binds);
            Binds = string.Join("\n", binds);
        }

        private void UpdateListTemplatesWidth(INui root)
        {
            if (root is NuiElement element)
            {
                if (element.draw_list != null)
                    foreach (var item in element.draw_list)
                        if (item is NuiDrawListText || item is NuiDrawListImage)
                        {
                            ((NuiDrawListItem)item).fill = new object();
                        }
            }
            if (root is IHaveChildrens parent)
            {
                foreach (var item in parent.children)
                {
                    UpdateListTemplatesWidth(item);
                }
            }
            else if (root is NuiList nuiList)
            {
                nuiList.UpdateTemplatesWidth();
            }
        }

        private void SearchBinds(CustomTreeViewItem customTreeViewItem, List<string> binds)
        {
            foreach (var prop in customTreeViewItem.Properties)
            {
                var isBindProp = prop.GetType().GetProperty("IsBind");
                if (isBindProp != null && (bool)isBindProp.GetValue(prop) == true)
                {
                    var isBindValue = prop.GetType().GetProperty("BindVar");
                    if (isBindValue != null)
                    {
                        string json = "jsonObject";
                        var jsonValueString = prop.GetType().GetCustomAttributes(typeof(JsonBindStringAttribute), false).FirstOrDefault();
                        if (jsonValueString != null)
                            json = ((JsonBindStringAttribute)jsonValueString).Value;
                        binds.Add($"NuiSetBind(oPC, nToken, \"{isBindValue.GetValue(prop)}\", {json});");
                    }
                }
            }
            foreach (CustomTreeViewItem item in customTreeViewItem.Items)
                SearchBinds(item, binds);
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

        private void buttonClearColorValue(object sender, RoutedEventArgs e)
        {
            NuiBindColorProperty property = (NuiBindColorProperty)((Button)sender).Tag;
            property.Clear();
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

        private void ClickSaveBinary(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "resref.nui";
            sfd.Filter = "project files|*.nui";
            if (sfd.ShowDialog() == true)
            {
                BinaryFormatter bin = new BinaryFormatter();
                using (var fs = File.Create(sfd.FileName))
                    bin.Serialize(fs, nui);
            }
        }

        private void ClickLoadBinary(object sender, RoutedEventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.FileName = "resref.nui";
            sfd.Filter = "project files|*.nui";
            if (sfd.ShowDialog() == true)
            {
                BinaryFormatter bin = new BinaryFormatter();
                try
                {
                    using (var fs = File.OpenRead(sfd.FileName))
                        nui = (NuiWindow)bin.Deserialize(fs);
                    ReloadTree();
                    Title = "Gem of the North Nui Creator - " + new FileInfo(sfd.FileName).Name;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ReloadTree()
        {
            Elements.Clear();
            var root = new CustomTreeViewItem { Header = nui.GetType().Name, ContextMenu = contextMenu, NuiElement = nui };
            var nextNode = AddNode(root, nui.root);
            BuildTree(nui.root, nextNode);
            Elements.Add(root);
            SignalChanged(nameof(Elements));
        }

        private void BuildTree(INui root, CustomTreeViewItem rootNode)
        {
            if (root is IHaveChildrens parent)
            {
                foreach (var item in parent.children)
                {
                    var nextNode = AddNode(rootNode, item);
                    BuildTree(item, nextNode);
                }
            }
            else if (root is NuiList nuiList)
            {
                var childs = nuiList.GetChilds();
                foreach (var item in childs)
                {
                    var nextNode = AddNode(rootNode, item);
                    BuildTree(item, nextNode);
                }
            }
            else if (root is NuiElement nui && nui.draw_list != null)
            {
                foreach (var item in nui.draw_list)
                {
                    var nextNode = AddNode(rootNode, item);
                    BuildTree(item, nextNode);
                }
            }
            else if (root is NuiChart chart)
            {
                foreach (INui item in chart.value)
                {
                    AddNode(rootNode, item);
                }
            }
        }

        private void buttonPickColor(object sender, RoutedEventArgs e)
        {
            NuiBindColorProperty color = ((Button)sender).Tag as NuiBindColorProperty;
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                color.A = colorDialog.Color.A;
                color.R = colorDialog.Color.R;
                color.G = colorDialog.Color.G;
                color.B = colorDialog.Color.B;
            }
        }

        private void buttonSaveArrayFloats(object sender, RoutedEventArgs e)
        {
            var array = ((Button)sender).Tag as NuiArrayFloatPairsSelectProperty;
            if (array != null)
                array.UpdateValues();
        }

    }
}
