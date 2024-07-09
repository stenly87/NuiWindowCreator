using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("JsonString()")]
    public class NuiBindStringProperty : NuiBindProperty<string>
    {
        public NuiBindStringProperty(FieldInfo fieldInfo, INui nuiElement, string description = null) : base(fieldInfo, nuiElement, description)
        {

        }
    }
}