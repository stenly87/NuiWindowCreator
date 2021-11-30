namespace NuiWindowCreator.NuiElements
{
    public class NuiTextEdit : NuiElement
    {
        public int multiline = 1;
        public int max = 65535;
        public NuiTextEdit()
        {
            type = "textedit";
            value = "text value";
            label = "text placeholder";
        }
    }
}
