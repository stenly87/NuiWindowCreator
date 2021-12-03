using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    public class NuiTextEdit : NuiElement
    {
        [GuiProperty(typeof(NuiSimpleBoolProperty))]
        public bool multiline = true;
        [GuiProperty(typeof(NuiSimpleIntProperty))]
        public int max = 65535;
        public NuiTextEdit()
        {
            type = "textedit";
            value = "text value";
            label = "text placeholder";
        }
    }
}
