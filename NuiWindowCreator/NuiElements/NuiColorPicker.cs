namespace NuiWindowCreator.NuiElements
{
    public class NuiColorPicker : NuiElement
    {
        [NuiBindable(typeof(NuiColor))]
        public new object value;
        public NuiColorPicker()
        {
            type = "color_picker";
            value = new NuiColor();
        }
    }
}
