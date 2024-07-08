using NuiWindowCreator.NuiProperties;
using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiToggles : NuiElement
    {
        [GuiProperty(typeof(NuiDirectionSelectProperty))]
        public NuiDirection direction = NuiDirection.HORIZONTAL;
        [GuiProperty(typeof(NuiArrayItemsSelectProperty))]
        [NuiBindable(typeof(List<string>))]
        public object elements = new List<string>();
        public NuiToggles()
        {
            type = "tabbar";
            value = new BindValue { bind = "tabbar_selected_index" };
        }
    }

}
