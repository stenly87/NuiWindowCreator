using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiTextEdit : NuiElement
    {
        [GuiProperty(typeof(NuiSimpleBoolProperty))]
        public bool multiline = true;
        [GuiProperty(typeof(NuiSimpleIntProperty), "UInt >= 1, <= 65535")]
        public int max = 65535;
        [GuiProperty(typeof(NuiSimpleBoolProperty))]
        public bool wordwrap = true;
        
        public NuiTextEdit()
        {
            type = "textedit";
            value = "text value";
            label = "text placeholder";
        }
    }
}
