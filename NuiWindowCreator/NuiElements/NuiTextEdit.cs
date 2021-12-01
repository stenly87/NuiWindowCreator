namespace NuiWindowCreator.NuiElements
{
    public class NuiTextEdit : NuiElement
    {
        public bool multiline = true;
        public int max = 65535;
        public NuiTextEdit()
        {
            type = "textedit";
            value = "text value";
            label = "text placeholder";
        }
    }
}
