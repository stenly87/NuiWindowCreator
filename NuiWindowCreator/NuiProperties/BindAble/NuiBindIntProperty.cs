using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("jsonInt")]
    public class NuiBindIntProperty : NuiBindProperty<int>
    {
        public NuiBindIntProperty(FieldInfo fieldInfo, INui nuiElement) : base(fieldInfo, nuiElement)
        {

        }
    }
}