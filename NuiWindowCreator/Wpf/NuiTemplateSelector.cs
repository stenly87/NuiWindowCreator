using NuiWindowCreator.NuiElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace NuiWindowCreator
{
    public class NuiTemplateSelector : DataTemplateSelector
    {
        DataTemplate defaultTemplate;
        DataTemplate nuiGeometryTemplate;
        DataTemplate defaultCanBindTemplate;
        DataTemplate nuiComboEntrysTemplate;


        public NuiTemplateSelector()
        {
            var window = App.Current.MainWindow;

            defaultTemplate = window.FindResource("defaultNuiTemplate") as DataTemplate;
            nuiGeometryTemplate = window.FindResource("nuiGeometryTemplate") as DataTemplate;
            defaultCanBindTemplate = window.FindResource("defaultCanBindTemplate") as DataTemplate;
            nuiComboEntrysTemplate = window.FindResource("nuiComboEntrysTemplate") as DataTemplate;

        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is NuiPropertyInfo prop)
            {
                if (prop.Value is NuiGeometry)
                    return nuiGeometryTemplate;
                else if (prop.Value is List<object[]>)
                    return nuiComboEntrysTemplate;
                else if (prop.Value is NuiDirection)
                    return GetNuiDirectionTemplate(typeof(NuiDirection));
                else if (prop.Value is NuiAspect)
                    return GetNuiDirectionTemplate(typeof(NuiAspect), true);
                else if (prop.Value is NuiHAlign)
                    return GetNuiDirectionTemplate(typeof(NuiHAlign), true);
                else if (prop.Value is NuiVAlign)
                    return GetNuiDirectionTemplate(typeof(NuiVAlign), true);
                else if (prop.Value is NuiScrollbars)
                    return GetNuiDirectionTemplate(typeof(NuiScrollbars));
                else if (prop.IsBindable)
                    return defaultCanBindTemplate;
                else
                    return defaultTemplate;
            } 
            return base.SelectTemplate(item, container);
        }

        Dictionary<Type, DataTemplate> enumsTemplates = new Dictionary<Type, DataTemplate>();

        private DataTemplate GetNuiDirectionTemplate(Type enumType, bool bindAble = false)
        {
            if (enumsTemplates.ContainsKey(enumType))
                return enumsTemplates[enumType];
            DataTemplate template = new DataTemplate();
            FrameworkElementFactory spGrid = new FrameworkElementFactory(typeof(Grid));
            FrameworkElementFactory spColumn = new FrameworkElementFactory(typeof(ColumnDefinition));
            spColumn.SetValue(ColumnDefinition.WidthProperty, new GridLength(75));
            spGrid.AppendChild(spColumn);
            spColumn = new FrameworkElementFactory(typeof(ColumnDefinition));
            spColumn.SetValue(ColumnDefinition.WidthProperty, new GridLength(75));
            spGrid.AppendChild(spColumn);
            spGrid.AppendChild(new FrameworkElementFactory(typeof(ColumnDefinition)));

            FrameworkElementFactory spLabel= new FrameworkElementFactory(typeof(Label));
            spLabel.SetValue(Label.ContentProperty, new Binding("Name"));
            spGrid.AppendChild(spLabel);
            if (bindAble)
            {
                FrameworkElementFactory spCheck = new FrameworkElementFactory(typeof(CheckBox));
                spCheck.SetValue(CheckBox.ContentProperty, "Bind");
                spCheck.SetValue(CheckBox.IsCheckedProperty, new Binding("IsBind"));
                spCheck.SetValue(Grid.ColumnProperty, 1);
                spGrid.AppendChild(spCheck);
            }
            FrameworkElementFactory spFactory = new FrameworkElementFactory(typeof(ComboBox));
            spFactory.SetValue(ComboBox.ItemsSourceProperty, enumType.GetEnumNames());
            spFactory.SetValue(ComboBox.SelectedValueProperty, new Binding("Value"));
            spFactory.SetValue(Grid.ColumnProperty, 2);
            spGrid.AppendChild(spFactory);
            template.VisualTree = spGrid;
            enumsTemplates.Add(enumType, template);
            return template;
        }
    }
}
