using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("jsonString")]
    public class NuiBindStringProperty : NuiBindProperty<string>
    {
        public NuiBindStringProperty(FieldInfo fieldInfo, INui nuiElement) : base(fieldInfo, nuiElement)
        {

        }
    }
}