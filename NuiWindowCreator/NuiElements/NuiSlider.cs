namespace NuiWindowCreator.NuiElements
{
    public class NuiSlider : NuiElement
    {
        [NuiBindable(typeof(int))]
        public object min = 0;
        [NuiBindable(typeof(int))]
        public object max = 100;
        [NuiBindable(typeof(int))]
        public object step = 1;
        public NuiSlider()
        {
            type = "slider";
            value = new BindValue { bind = "slider_value"};
        }
    }
}
