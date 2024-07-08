using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiSliderFloat : NuiElement
    {
        [GuiProperty(typeof(NuiBindFloatProperty))]
        [NuiBindable(typeof(float))]
        public object min = 0.0f;
        [GuiProperty(typeof(NuiBindFloatProperty))]
        [NuiBindable(typeof(float))]
        public object max = 10.0f;
        [GuiProperty(typeof(NuiBindFloatProperty))]
        [NuiBindable(typeof(float))]
        public object step = 1.0f;
        [NuiUnic()]
        [GuiProperty(typeof(NuiBindFloatProperty))]
        [NuiBindable(typeof(float))]
        public new object value;
        public NuiSliderFloat()
        {
            type = "sliderf";
            value = new BindValue { bind = "slider_value" };
        }
    }
}
