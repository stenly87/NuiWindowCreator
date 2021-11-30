using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    public class NuiCol : NuiElement, IHaveChildrens
    {
        public List<NuiElement> children { get; set; } = new List<NuiElement>();
        public NuiCol()
        {
            type = "col";
        }
        public bool AddChildren(NuiElement child)
        {
            children.Add(child);
            return true;
        }
        public void RemoveChildren(NuiElement child)
        {
            children.Remove(child);
        }
    }
}
