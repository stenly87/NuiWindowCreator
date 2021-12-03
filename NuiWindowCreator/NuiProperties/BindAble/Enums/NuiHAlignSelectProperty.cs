using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    public class NuiHAlignSelectProperty : NuiBindEnumSelectProperty<NuiHAlign>
    {
        public NuiHAlignSelectProperty(FieldInfo fieldInfo, INui nuiElement) : base(fieldInfo, nuiElement)
        {
        }
    }
}