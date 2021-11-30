namespace NuiWindowCreator.NuiElements
{
    public class NuiLabel : NuiElement
    {
        public object text_halign;
        public object text_valign;
        public NuiLabel()
        {
            type = "label";
            value = "title";

            text_halign = NuiHAlign.LEFT;
            text_valign = NuiVAlign.MIDDLE;
        }
    }

}
