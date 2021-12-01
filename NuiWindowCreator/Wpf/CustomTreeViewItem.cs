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
        IEnumerable<NuiPropertyInfo> nuiPropertyInfos;
        public IEnumerable<NuiPropertyInfo> Properties {

            get
            {
                if (nuiPropertyInfos == null)
                    nuiPropertyInfos = NuiElement?.GetType().GetFields().
                    Select(s => new NuiPropertyInfo(s.Name, s.GetValue(NuiElement), s, NuiElement)).
                    Where(s => s.fieldInfo.GetCustomAttributes(typeof(NuiIgnorePropertyAttribute), false).Length == 0);
                return nuiPropertyInfos;
            }
        }

        public INui NuiElement { get; set; }
    }
}
