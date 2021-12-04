using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("jsonInt")]
    public class NuiHAlignSelectProperty : NuiBindEnumSelectProperty<NuiHAlign>
    {
        public NuiHAlignSelectProperty(FieldInfo fieldInfo, INui nuiElement) : base(fieldInfo, nuiElement)
        {
        }
    }
}