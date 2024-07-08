using NuiWindowCreator.NuiProperties;
using System.Collections.Generic;
using System.Windows.Documents;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiChart : NuiElement
    {
        [NuiIgnoreProperty()]   
        public new List<object> value = new List<object>();

        public NuiChart()
        {
            type = "chart";
            label = null;
        }

        public NuiChartSlot AddChildren()
        {
            var slot = new NuiChartSlot();
            value.Add(slot);
            return slot;
        }

        public void RemoveChildren(INui child)
        {
            value.Remove(child);
        }

    }
}

