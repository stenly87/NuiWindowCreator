using NuiWindowCreator.NuiElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NuiWindowCreator
{
    public class CustomTreeViewItem : TreeViewItem
    {
        public FieldInfo[] Properties {

            get
            {
                var props = NuiElement?.GetType().GetFields();
                return props;
            }
        }

        public INui NuiElement { get; set; }
    }
}
