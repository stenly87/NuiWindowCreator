using NuiWindowCreator.NuiProperties;
using NuiWindowCreator.NuiStructs;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiDrawListLine : NuiDrawListItem
    {
        [GuiProperty(typeof(NuiBindVec2Property))]
        [NuiBindable(typeof(NuiVec2))]
        public object a = new NuiVec2();
        [GuiProperty(typeof(NuiBindVec2Property))]
        [NuiBindable(typeof(NuiVec2))]
        public object b = new NuiVec2();

        public NuiDrawListLine()
        {
            type = 6;
            fill = false;
        }
    }
}
