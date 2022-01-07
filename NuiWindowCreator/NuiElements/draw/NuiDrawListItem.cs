using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiDrawListItem : INui
    {
        [GuiProperty(typeof(NuiBindBoolNullableProperty))]
        [NuiBindable(typeof(bool?))]
        public object enabled;
        [GuiProperty(typeof(NuiBindColorProperty))]
        [NuiBindable(typeof(NuiColor))]
        public object color;
        [GuiProperty(typeof(NuiBindBoolProperty))]
        [NuiBindable(typeof(bool))]
        public object fill;
        [GuiProperty(typeof(NuiBindFloatProperty))]
        [NuiBindable(typeof(float))]
        public object line_thickness;
        [NuiIgnoreProperty]
        public int type;

        public NuiDrawListItem()
        {
            line_thickness = 1.0f;
            fill = false;
            enabled = true;
            color = new NuiColor();
        }
    }
}
