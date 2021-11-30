using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    public class NuiOptions : NuiElement
    {
        public NuiDirection direction = NuiDirection.HORIZONTAL;
        public List<string> elements = new List<string>();
        public NuiOptions()
        {
            type = "options";
            value = 0;
        }
    }

}
