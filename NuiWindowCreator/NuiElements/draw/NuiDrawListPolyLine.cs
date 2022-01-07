using NuiWindowCreator.NuiProperties;
using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiDrawListPolyLine : NuiDrawListItem
    {
        [GuiProperty(typeof(NuiArrayFloatPairsSelectProperty))]
        [NuiBindable(typeof(List<float>))]
        public object points;
        public NuiDrawListPolyLine()
        {
            type = 0;
        }
    }
}
