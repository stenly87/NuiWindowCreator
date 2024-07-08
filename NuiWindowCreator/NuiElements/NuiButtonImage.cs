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
        [GuiProperty(typeof(NuiBindGeometryProperty))]
        [NuiBindable(typeof(NuiGeometry))]
        public object image_region;

        public NuiButtonImage()
        {
            type = "button_image";
            label = "image_ref";
        }
    }
}
