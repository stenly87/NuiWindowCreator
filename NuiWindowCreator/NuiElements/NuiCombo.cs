using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    public class NuiCombo : NuiElement
    {
        public List<object[]> elements = new List<object[]>();
        public NuiCombo()
        {
            type = "combo";
            value = 0;
        }

        public void AddElement(NuiElement nuiElement)
        {
            elements.Add(new object[] { nuiElement, elements.Count + 1});
        }
    }
}
