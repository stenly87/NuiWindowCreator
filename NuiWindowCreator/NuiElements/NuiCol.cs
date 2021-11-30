using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    public class NuiCol : NuiElement
    {
        public List<NuiElement> children = new List<NuiElement>();
        public NuiCol()
        {
            type = "col";
        }
    }
}
