using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuiWindowCreator.NuiElements;
using NuiWindowCreator.NuiProperties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NuiWindowCreator
{
    public class CustomTreeViewItem : TreeViewItem, ICloneable
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

        public object Clone()
        {
            BinaryFormatter bin = new BinaryFormatter();
            INui cloneINui;
            using (var ms = new MemoryStream())
            {
                bin.Serialize(ms, NuiElement);
                ms.Seek(0, SeekOrigin.Begin);
                cloneINui = (INui)bin.Deserialize(ms);
            }
            return new CustomTreeViewItem { Header = cloneINui.GetType().Name, ContextMenu = this.ContextMenu, NuiElement = cloneINui };
        }
    }
}
