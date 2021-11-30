namespace NuiWindowCreator.NuiElements
{
    public class NuiSlider : NuiElement
    {
        public object min = 0;
        public object max = 100;
        public object step = 1;
        public NuiSlider()
        {
            type = "slider";
            value = 0;
        }
    }
}
