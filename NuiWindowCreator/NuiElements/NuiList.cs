using System;
using System.Collections.Generic;
using System.Linq;

namespace NuiWindowCreator.NuiElements
{
    public class NuiList : NuiElement
    {
        public List<object[]> row_template = new List<object[]>();
        [NuiBindable(typeof(int))]
        public object row_count = 0;
        public float row_height = 25.0f;
        public NuiList()
        {
            type = "list";
        }

        public void AddTemplateCell(INui nuiElement)
        {
            row_template.Add(new object[] { nuiElement, 0.0f, true});
        }

        internal void RemoveTemplateCell(INui nuiElement)
        {
            var row = row_template.FirstOrDefault(s => s[0] == nuiElement);
            row_template.Remove(row);
        }

        internal void ReplaceTemplateCell(INui nuiElement, IHaveChildrens element)
        {
            var row = row_template.FirstOrDefault(s => s[0] == nuiElement);
            int index = row_template.IndexOf(row);
            row_template[index] = new object[] { element, 0.0f, true };
        }
    }
}
