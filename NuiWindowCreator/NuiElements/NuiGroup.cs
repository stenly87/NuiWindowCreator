using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    public partial class NuiGroup : NuiElement
    {
        public List<NuiElement> children = new List<NuiElement>();
        public bool border;
        public NuiScrollbars scrollbars;
        public NuiGroup()
        {
            type = "group";
            border = true;
            scrollbars = NuiScrollbars.AUTO;
        }
    }
}
