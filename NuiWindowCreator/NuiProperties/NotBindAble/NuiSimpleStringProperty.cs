using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    public class NuiSimpleStringProperty : NuiSimpleProperty<string>
    {
        public NuiSimpleStringProperty(FieldInfo fieldInfo, INui nuiElement, string description = null) : base(fieldInfo, nuiElement, description)
        {

        }
    }
}