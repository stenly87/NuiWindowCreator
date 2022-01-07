using NuiWindowCreator.NuiProperties;
using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiDrawListCircle : NuiDrawListItem
    {
        [GuiProperty(typeof(NuiBindGeometryProperty))]
        [NuiBindable(typeof(NuiGeometry))]
        public object rect;
        public NuiDrawListCircle()
        {
            type = 2;
            fill = false;
            rect = new NuiGeometry(0,0,10,10);
        }
    }
}
