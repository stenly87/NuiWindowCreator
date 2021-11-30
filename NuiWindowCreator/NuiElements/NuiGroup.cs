using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    public partial class NuiGroup : NuiElement, IHaveChildrens
    {
        public List<NuiElement> children { get; set; } = new List<NuiElement>();
        public bool border;
        public NuiScrollbars scrollbars;
        public NuiGroup()
        {
            type = "group";
            border = true;
            scrollbars = NuiScrollbars.AUTO;
        }
        public bool AddChildren(NuiElement child)
        {
            if (children.Count > 0)
                return false;

            children.Add(child);
            return true;
        }
        public void RemoveChildren(NuiElement child)
        {
            children.Remove(child);
        }
    }
}
