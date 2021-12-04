using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("jsonInt")]
    public class NuiVAlignSelectProperty : NuiBindEnumSelectProperty<NuiVAlign>
    {
        public NuiVAlignSelectProperty(FieldInfo fieldInfo, INui nuiElement) : base(fieldInfo, nuiElement)
        {
        }
    }
}