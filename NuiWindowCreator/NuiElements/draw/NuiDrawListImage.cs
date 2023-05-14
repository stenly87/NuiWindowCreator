using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiDrawListImage : NuiDrawListItem
    {
        [GuiProperty(typeof(NuiBindGeometryProperty))]
        [NuiBindable(typeof(NuiGeometry))]
        public object rect;
        [GuiProperty(typeof(NuiBindStringProperty))]
        [NuiBindable(typeof(string))]
        public object image;
        [GuiProperty(typeof(NuiAspectSelectProperty))]
        [NuiBindable(typeof(NuiAspect))]
        public object image_aspect;
        [GuiProperty(typeof(NuiHAlignSelectProperty))]
        [NuiBindable(typeof(NuiHAlign))]
        public object image_halign;
        [GuiProperty(typeof(NuiVAlignSelectProperty))]
        [NuiBindable(typeof(NuiVAlign))]
        public object image_valign;
        public NuiDrawListImage()
        {
            type = 5;
            fill = null;
            line_thickness = null;
            color = new NuiColor();
            rect = new NuiGeometry(0, 0, 10, 10);
            image_aspect = NuiAspect.FILL;
            image_halign = NuiHAlign.CENTER;
            image_valign = NuiVAlign.MIDDLE;
        }
    }
}
