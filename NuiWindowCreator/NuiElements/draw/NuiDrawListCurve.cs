using NuiWindowCreator.NuiProperties;
using NuiWindowCreator.NuiStructs;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiDrawListCurve : NuiDrawListItem
    {
        [GuiProperty(typeof(NuiBindVec2Property))]
        [NuiBindable(typeof(NuiVec2))]
        public object a = new NuiVec2();
        [GuiProperty(typeof(NuiBindVec2Property))]
        [NuiBindable(typeof(NuiVec2))]
        public object b = new NuiVec2();
        [GuiProperty(typeof(NuiBindVec2Property))]
        [NuiBindable(typeof(NuiVec2))]
        public object ctrl0 = new NuiVec2();
        [GuiProperty(typeof(NuiBindVec2Property))]
        [NuiBindable(typeof(NuiVec2))]
        public object ctrl1 = new NuiVec2();
        public NuiDrawListCurve()
        {
            type = 1;
            fill = false;
        }
    }
}
