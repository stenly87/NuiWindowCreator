using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("JsonBool()")]
    public class NuiBindBoolNullableProperty : NuiBindProperty<bool?>
    {
        public NuiBindBoolNullableProperty(FieldInfo fieldInfo, INui nuiElement) : base(fieldInfo, nuiElement)
        {

        }
    }
}