using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiButtonImage : NuiElement
    {
        public NuiButtonImage()
        {
            type = "button_image";
            label = "image_ref";
        }
    }
}
