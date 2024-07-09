using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("JsonBool()")]
    public class NuiBindBoolProperty : NuiBindProperty<bool>
    {
        public NuiBindBoolProperty(FieldInfo fieldInfo, INui nuiElement, string description = null): base(fieldInfo, nuiElement, description)
        {

        }
    }
}