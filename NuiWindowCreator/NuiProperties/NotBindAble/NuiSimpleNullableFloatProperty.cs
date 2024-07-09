using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    public class NuiSimpleNullableFloatProperty : NuiSimpleProperty<float?>
    {
        public NuiSimpleNullableFloatProperty(FieldInfo fieldInfo, INui nuiElement, string description = null) : base(fieldInfo, nuiElement, description)
        {

        }
    }
}