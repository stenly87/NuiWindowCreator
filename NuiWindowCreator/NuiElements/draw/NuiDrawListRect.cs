using NuiWindowCreator.NuiProperties;
using NuiWindowCreator.NuiStructs;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiDrawListRect : NuiDrawListItem
    {
        [GuiProperty(typeof(NuiBindGeometryProperty))]
        [NuiBindable(typeof(NuiGeometry))]
        public object rect;

        public NuiDrawListRect()
        {
            type = 7;
            fill = false;
        }
    }
}
