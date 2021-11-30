using NuiWindowCreator.NuiElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NuiWindowCreator
{
    public class CustomTreeViewItem : TreeViewItem
    {
        public IEnumerable<NuiPropertyInfo> Properties {

            get
            {
                var props = NuiElement?.GetType().GetFields().
                    Select(s => new NuiPropertyInfo(s.Name, s.GetValue(NuiElement), s, NuiElement)).
                    Where(s => s.fieldInfo.GetCustomAttributes(typeof(NuiIgnorePropertyAttribute), false).Length == 0);
                return props;
            }
        }

        public INui NuiElement { get; set; }
    }
}
