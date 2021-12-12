using NuiWindowCreator.NuiProperties;
using System;
using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiCombo : NuiElement
    {
        [GuiProperty(typeof(NuiComboItemsSelectProperty))]
        [NuiBindable(typeof(List<object[]>))]
        public object elements = new List<object[]>();

        [NuiUnic()]
        [GuiProperty(typeof(NuiBindIntProperty))]
        [NuiBindable(typeof(int))]
        public new object value = new BindValue { bind = "combo_selected_index" };
        public NuiCombo()
        {
            type = "combo";
            ((List<object[]>)elements).Add(new object[] { "row 1", 1 });
            ((List<object[]>)elements).Add(new object[] { "row 2", 2 });
        }
    }
}
