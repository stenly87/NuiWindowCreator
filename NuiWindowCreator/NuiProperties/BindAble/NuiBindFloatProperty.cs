using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("JsonFloat()")]
    public class NuiBindFloatProperty : NuiBindProperty<float>
    {
        public NuiBindFloatProperty(FieldInfo fieldInfo, INui nuiElement, string description = null) : base(fieldInfo, nuiElement, description)
        {

        }
    }

    [JsonBindString("JsonFloat()")]
    public class NuiBindFloatNullableProperty : NuiBindProperty<float?>
    {
        public NuiBindFloatNullableProperty(FieldInfo fieldInfo, INui nuiElement, string description = null) : base(fieldInfo, nuiElement, description)
        {

        }
    }
}