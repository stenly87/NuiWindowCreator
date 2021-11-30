namespace NuiWindowCreator.NuiElements
{
    public class NuiImage : NuiElement
    {
        [NuiBindable(typeof(int))]
        public object image_aspect;
        [NuiBindable(typeof(int))]
        public object image_halign;
        [NuiBindable(typeof(int))]
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
