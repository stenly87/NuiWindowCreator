using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    public class NuiDirectionSelectProperty : NuiEnumSelectProperty<NuiDirection>
    {
        public NuiDirectionSelectProperty(FieldInfo fieldInfo, INui nuiElement, string description = null) : base(fieldInfo, nuiElement, description)
        {
        }
    }
}