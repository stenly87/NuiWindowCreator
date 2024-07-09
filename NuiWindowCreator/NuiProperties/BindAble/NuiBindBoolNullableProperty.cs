using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("JsonBool()")]
    public class NuiBindBoolNullableProperty : NuiBindProperty<bool?>
    {
        public NuiBindBoolNullableProperty(FieldInfo fieldInfo, INui nuiElement, string description = null) : base(fieldInfo, nuiElement, description)
        {

        }
    }

    [JsonBindString("JsonBool()")]
    public class NuiBindBoolObjectNullableProperty : NuiBindProperty<object>
    {
        public NuiBindBoolObjectNullableProperty(FieldInfo fieldInfo, INui nuiElement, string description = null) : base(fieldInfo, nuiElement, description)
        {

        }
    }
}