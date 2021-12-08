using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiColorPicker : NuiElement
    {
        [NuiUnic()]
        [GuiProperty(typeof(NuiBindColorProperty))]
        [NuiBindable(typeof(NuiColor))]
        public new object value;
        public NuiColorPicker()
        {
            type = "color_picker";
            value = new NuiColor();
        }
    }
}
