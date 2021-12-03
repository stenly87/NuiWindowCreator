using NuiWindowCreator.NuiProperties;
using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiOptions : NuiElement
    {
        [GuiProperty(typeof(NuiDirectionSelectProperty))]
        public NuiDirection direction = NuiDirection.HORIZONTAL;
        [GuiProperty(typeof(NuiArrayItemsSelectProperty))]
        [NuiBindable(typeof(List<string>))]
        public object elements = new List<string>();
        public NuiOptions()
        {
            type = "options";
            value = new BindValue { bind = "options_selected_index"};
        }
    }

}
