using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    public class NuiBindBoolNullableProperty : NuiBindProperty<bool?>
    {
        public NuiBindBoolNullableProperty(FieldInfo fieldInfo, INui nuiElement) : base(fieldInfo, nuiElement)
        {

        }
    }
}