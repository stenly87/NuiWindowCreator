using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiImage : NuiElement
    {
        [GuiProperty(typeof(NuiAspectSelectProperty))]
        [NuiBindable(typeof(NuiAspect))]
        public object image_aspect;
        [GuiProperty(typeof(NuiHAlignSelectProperty))]
        [NuiBindable(typeof(NuiHAlign))]
        public object image_halign;
        [GuiProperty(typeof(NuiVAlignSelectProperty))]
        [NuiBindable(typeof(NuiVAlign))]
        public object image_valign;

        public NuiImage()
        {
            type = "image";
            value = "img_resref";
            image_aspect = NuiAspect.FILL;
            image_halign = NuiHAlign.CENTER;
            image_valign = NuiVAlign.MIDDLE;
        }
    }
}
