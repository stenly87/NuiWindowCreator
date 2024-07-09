using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiChartSlot : INui
    {
        [GuiProperty(typeof(NuiBindColorProperty), "Current chart slot color")]
        [NuiBindable(typeof(NuiColor))]
        public object color = new NuiColor();

        [GuiProperty(typeof(NuiBindStringProperty), "Current chart slot data (Float[])")]
        [NuiBindable(typeof(string))]
        public object data = new BindValue { bind = "bind_float_array" };

        [GuiProperty(typeof(NuiBindStringProperty), "Current chart slot legend")]
        [NuiBindable(typeof(string))]
        public object legend;

        [NuiIgnoreProperty]
        public int type = 0;
    }
}