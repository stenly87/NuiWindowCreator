using NuiWindowCreator.NuiElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NuiWindowCreator
{
    public class NuiTemplateSelector : DataTemplateSelector
    {
        DataTemplate defaultTemplate;
        DataTemplate nuiGeometryTemplate;
        DataTemplate defaultCanBindTemplate;

        public NuiTemplateSelector()
        {
            var window = App.Current.MainWindow;

            defaultTemplate = window.FindResource("defaultNuiTemplate") as DataTemplate;
            nuiGeometryTemplate = window.FindResource("nuiGeometryTemplate") as DataTemplate;
            defaultCanBindTemplate = window.FindResource("defaultCanBindTemplate") as DataTemplate;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is NuiPropertyInfo prop)
            {
                if (prop.Value is NuiGeometry)
                    return nuiGeometryTemplate;
                else if (prop.IsBindable)
                    return defaultCanBindTemplate;
                else
                    return defaultTemplate;
            } 
            return base.SelectTemplate(item, container);
        }
    }
}
