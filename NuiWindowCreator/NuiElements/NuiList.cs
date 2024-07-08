using NuiWindowCreator.NuiProperties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiList : NuiElement
    {
        [NuiIgnoreProperty]
        public List<object[]> row_template = new List<object[]>();
        [GuiProperty(typeof(NuiBindIntProperty))]
        [NuiBindable(typeof(int))]
        public object row_count = new BindValue { bind = "list_row_count" };
        [GuiProperty(typeof(NuiSimpleFloatProperty))]
        public float row_height = 25.0f;
        [GuiProperty(typeof(NuiScrollSelectProperty))]
        public NuiScrollbars scrollbars;

        public NuiList()
        {
            type = "list";
            scrollbars = NuiScrollbars.Y;
        }

        internal void AddTemplateCell(INui nuiElement)
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

        internal IEnumerable<INui> GetChilds()
        {
            return row_template.Select(s => (INui)s[0]);
        }

        internal void UpdateTemplatesWidth()
        {
            row_template.ForEach(row => {
                if (row[0] is NuiElement nui && nui.width != null)
                {
                    row[1] = nui.width;
                }
            });
        }

        internal void MoveUpTemplateCell(INui nuiElement)
        {
            var row = row_template.FirstOrDefault(s => s[0] == nuiElement);
            int index = row_template.IndexOf(row);
            row_template.Remove(row);
            row_template.Insert(--index, row);
        }

        internal void MoveDownTemplateCell(INui nuiElement)
        {
            var row = row_template.FirstOrDefault(s => s[0] == nuiElement);
            int index = row_template.IndexOf(row);
            row_template.Remove(row);
            row_template.Insert(++index, row);
        }
    }
}

