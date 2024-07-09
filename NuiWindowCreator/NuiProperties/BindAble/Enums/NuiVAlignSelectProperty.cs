using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("JsonInt()")]
    public class NuiVAlignSelectProperty : NuiBindEnumSelectProperty<NuiVAlign>
    {
        public NuiVAlignSelectProperty(FieldInfo fieldInfo, INui nuiElement, string description) : base(fieldInfo, nuiElement, description)
        {
        }
    }
}