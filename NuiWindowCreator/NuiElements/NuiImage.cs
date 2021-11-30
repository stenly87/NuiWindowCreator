namespace NuiWindowCreator.NuiElements
{
    public class NuiImage : NuiElement
    {
        public object image_aspect;
        public object image_halign;
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
