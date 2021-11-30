using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuiWindowCreator.NuiElements
{
    public class NuiButton : NuiElement
    {
        public NuiButton()
        {
            type = "button";
            label = "Кнопка";
        }
    }

    public class List : NuiElement
    {
        public List<object[]> row_template = new List<object[]>();
        public object row_count = 0;
        public float row_height = 25.0f;
        public List()
        {
            type = "list";
        }

        public void AddTemplateCell(NuiElement nuiElement)
        {
            row_template.Add(new object[] { nuiElement, 0.0f, true});
        }
    }

    
}
