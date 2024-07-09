using NuiWindowCreator.NuiElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuiWindowCreator.NuiProperties
{
    static class PropertyFactory
    {
        public static NuiProperty GetPropertyFromType(System.Reflection.FieldInfo fieldInfo, INui nuiElement)
        {
            var bindProps = fieldInfo.GetCustomAttributes(typeof(NuiBindableAttribute), false);
            var bindAble = bindProps.Length != 0;
            var valueType = bindAble ? ((NuiBindableAttribute)bindProps.First()).TargetType : fieldInfo.FieldType;

            var GuiProperty = fieldInfo.GetCustomAttributes(typeof(GuiPropertyAttribute), false);
            if (GuiProperty.Length > 0)
            {
                GuiPropertyAttribute guiProperty = (GuiPropertyAttribute)GuiProperty.First();
                return (NuiProperty)Activator.CreateInstance(guiProperty.TargetType, new object[] { fieldInfo, nuiElement, guiProperty.Description });
            }
            return new ErrorProperty<string>(fieldInfo, nuiElement);
        }
    }
}
