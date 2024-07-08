using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiText : NuiElement
    {
        [GuiProperty(typeof(NuiScrollSelectProperty))]
        public NuiScrollbars scrollbars;

        public NuiText()
        {
            type = "text";
            value = "text";
            scrollbars = NuiScrollbars.AUTO;
        }
    }
}
