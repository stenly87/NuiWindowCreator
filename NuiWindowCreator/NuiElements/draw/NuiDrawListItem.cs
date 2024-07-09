using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiDrawListItem : INui
    {
        [GuiProperty(typeof(NuiBindBoolProperty))]
        [NuiBindable(typeof(bool))]
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
        [GuiProperty(typeof(NuiSimpleIntProperty), "You can order draw list items to be painted either before, or after the\r\nbuiltin render of the widget in question. This enables you to paint \"behind\" a widget.\r\nBEFORE = -1\r\nAFTER = 1")]
        public int order = 1;
        [GuiProperty(typeof(NuiSimpleIntProperty), "Always render draw list item (default) = 0\r\nOnly render when NOT hovering = 1\r\nOnly render when mouse is hovering = 2\r\nOnly render while LMB is held down = 3;\r\nOnly render while RMB is held down = 4;\r\nOnly render while MMB is held down = 5")]
        public int render = 0;
        [GuiProperty(typeof(NuiSimpleBoolProperty), "Values in binds are considered arrays-of-values")]
        public bool arrayBinds = false;

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
