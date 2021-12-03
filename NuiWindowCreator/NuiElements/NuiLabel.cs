using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    public class NuiLabel : NuiElement
    {
        [GuiProperty(typeof(NuiHAlignSelectProperty))]
        [NuiBindable(typeof(NuiHAlign))]
        public object text_halign;
        [GuiProperty(typeof(NuiVAlignSelectProperty))]
        [NuiBindable(typeof(NuiVAlign))]
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
