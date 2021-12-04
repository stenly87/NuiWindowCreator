using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("jsonInt")]
    public class NuiAspectSelectProperty : NuiBindEnumSelectProperty<NuiAspect>
    {
        public NuiAspectSelectProperty(FieldInfo fieldInfo, INui nuiElement) : base(fieldInfo, nuiElement)
        {
        }
    }
}