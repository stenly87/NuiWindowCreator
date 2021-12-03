using NuiWindowCreator.NuiProperties;
using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public partial class NuiGroup : NuiElement, IHaveChildrens
    {
        public List<INui> children { get; set; } = new List<INui>();
        [GuiProperty(typeof(NuiSimpleBoolProperty))]
        public bool border;
        [GuiProperty(typeof(NuiScrollSelectProperty))]
        public NuiScrollbars scrollbars;
        public NuiGroup()
        {
            type = "group";
            border = true;
            scrollbars = NuiScrollbars.AUTO;
        }
        public bool AddChildren(INui child)
        {
            if (children.Count > 0)
                return false;

            children.Add(child);
            return true;
        }
        public void RemoveChildren(INui child)
        {
            children.Remove(child);
        }

        public void ReplaceChildren(INui oldChild, INui newChild)
        {
            int index = children.IndexOf(oldChild);
            children[index] = newChild;
        }
    }
}
