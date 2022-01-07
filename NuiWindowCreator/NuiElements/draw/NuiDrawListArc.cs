using NuiWindowCreator.NuiProperties;
using NuiWindowCreator.NuiStructs;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiDrawListArc : NuiDrawListItem
    {
        [GuiProperty(typeof(NuiBindVec2Property))]
        [NuiBindable(typeof(NuiVec2))]
        public object c = new NuiVec2();
        [GuiProperty(typeof(NuiBindFloatProperty))]
        [NuiBindable(typeof(NuiVec2))]
        public object radius = 1.0f;
        [GuiProperty(typeof(NuiBindFloatProperty))]
        [NuiBindable(typeof(NuiVec2))]
        public object amin = 1.0f;
        [GuiProperty(typeof(NuiBindFloatProperty))]
        [NuiBindable(typeof(NuiVec2))]
        public object amax = 10.0f;
        public NuiDrawListArc()
        {
            type = 3;
        }
    }
}
