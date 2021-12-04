using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("jsonBool")]
    public class NuiBindBoolNullableProperty : NuiBindProperty<bool?>
    {
        public NuiBindBoolNullableProperty(FieldInfo fieldInfo, INui nuiElement) : base(fieldInfo, nuiElement)
        {

        }
    }
}