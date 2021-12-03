using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    internal class NuiSimpleFloatProperty : NuiSimpleProperty<float>
    {
        public NuiSimpleFloatProperty(FieldInfo fieldInfo, INui nuiElement) : base(fieldInfo, nuiElement)
        {

        }
    }
}