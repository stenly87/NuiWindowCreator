using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiSlider : NuiElement
    {
        [GuiProperty(typeof(NuiBindIntProperty))]
        [NuiBindable(typeof(int))]
        public object min = 0;
        [GuiProperty(typeof(NuiBindIntProperty))]
        [NuiBindable(typeof(int))]
        public object max = 100;
        [GuiProperty(typeof(NuiBindIntProperty))]
        [NuiBindable(typeof(int))]
        public object step = 1;
        [GuiProperty(typeof(NuiBindIntProperty))]
        [NuiBindable(typeof(int))]
        public new object value;
        public NuiSlider()
        {
            type = "slider";
            value = new BindValue { bind = "slider_value"};
        }
    }
}
