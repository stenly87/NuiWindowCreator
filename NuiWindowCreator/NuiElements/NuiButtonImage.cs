using NuiWindowCreator.NuiProperties;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiButtonImage : NuiElement
    {
        [GuiProperty(typeof(NuiBindGeometryProperty), "Optionally render only subregion of jImage.  This property can be set on\r\nNuiImage and NuiButtonImage widgets.\r\njRegion is a NuiRect (x, y, w, h) to indicate the render region inside the image.")]
        [NuiBindable(typeof(NuiGeometry))]
        public object image_region;

        public NuiButtonImage()
        {
            type = "button_image";
            label = "image_ref";
        }
    }
}
