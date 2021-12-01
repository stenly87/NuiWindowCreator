using System;
using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    public class NuiCombo : NuiElement
    {
        [NuiBindable(typeof(List<object[]>))]
        public object elements = new List<object[]>();

        [NuiBindable(typeof(int))]
        public new object value = new BindValue { bind = "combo_selected_index" };
        public NuiCombo()
        {
            type = "combo";
            value = 0;
        }
    }
}
