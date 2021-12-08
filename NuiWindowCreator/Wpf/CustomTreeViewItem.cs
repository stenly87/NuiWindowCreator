using NuiWindowCreator.NuiElements;
using NuiWindowCreator.NuiProperties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NuiWindowCreator
{
    public class CustomTreeViewItem : TreeViewItem
    {
        ObservableCollection<NuiProperty> nuiPropertyInfos;
        public IEnumerable<NuiProperty> Properties
        {
            get
            {
                if (nuiPropertyInfos == null)
                {
                    nuiPropertyInfos = new ObservableCollection<NuiProperty>(
                        NuiElement?.GetType().GetFields().
                        Where(s =>
                        s.GetCustomAttributes(typeof(NuiUnicAttribute), false).Length == 0 &&
                        s.GetCustomAttributes(typeof(NuiIgnorePropertyAttribute), false).Length == 0).
                        Select(s => PropertyFactory.GetPropertyFromType(s, NuiElement))
                        );
                    var valueField = NuiElement?.GetType().GetFields().
                        Where(s => s.GetCustomAttributes(typeof(NuiUnicAttribute), false).Length != 0).FirstOrDefault();
                    if (valueField != null)
                        nuiPropertyInfos.Insert(0, PropertyFactory.GetPropertyFromType(valueField, NuiElement));
                }
                return nuiPropertyInfos;
            }
        }

        public INui NuiElement { get; set; }
    }
}
