using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    public class NuiRow : NuiElement
    {
        public List<NuiElement> children = new List<NuiElement>();
        public NuiRow()
        {
            type = "row";
        }
    }
}
