using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiElement : INui
    {
        [GuiProperty(typeof(NuiSimpleStringProperty))]
        public string id;
        [NuiIgnoreProperty]
        public string type;
        [GuiProperty(typeof(NuiBindStringProperty))]
        [NuiBindable(typeof(string))]
        public object label = "";
        [GuiProperty(typeof(NuiBindStringProperty))]
        [NuiBindable(typeof(string))]
        public object value;
        [GuiProperty(typeof(NuiBindStringProperty))]
        [NuiBindable(typeof(string))]
        public object tooltip;

        [GuiProperty(typeof(NuiSimpleNullableFloatProperty))]
        public float? width;
        [GuiProperty(typeof(NuiSimpleNullableFloatProperty))]
        public float? height;
        [GuiProperty(typeof(NuiSimpleNullableFloatProperty))]
        public float? aspect;
        [GuiProperty(typeof(NuiSimpleNullableFloatProperty))]
        public float? margin;
        [GuiProperty(typeof(NuiSimpleNullableFloatProperty))]
        public float? padding;

        [GuiProperty(typeof(NuiBindBoolNullableProperty))]
        [NuiBindable(typeof(bool?))]
        public object enabled;
        [GuiProperty(typeof(NuiBindBoolNullableProperty))]
        [NuiBindable(typeof(bool?))]
        public object visible;

        [GuiProperty(typeof(NuiBindColorProperty))]
        [NuiBindable(typeof(NuiColor))]
        public object foreground_color;
    }
}
