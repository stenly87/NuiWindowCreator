using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("JsonInt()")]
    public class NuiHAlignSelectProperty : NuiBindEnumSelectProperty<NuiHAlign>
    {
        public NuiHAlignSelectProperty(FieldInfo fieldInfo, INui nuiElement, string description) : base(fieldInfo, nuiElement, description)
        {
        }
    }
}