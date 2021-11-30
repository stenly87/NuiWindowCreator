using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    public class NuiRow : NuiElement, IHaveChildrens
    {
        public List<NuiElement> children { get; set; } = new List<NuiElement>();
        public NuiRow()
        {
            type = "row";
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
