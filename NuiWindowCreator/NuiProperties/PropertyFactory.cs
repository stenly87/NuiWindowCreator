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

            if (!bindAble)
            {
                if (valueType == typeof(bool))
                    return new NuiSimpleBoolProperty(fieldInfo, nuiElement);
                else if (valueType == typeof(int))
                    return new NuiSimpleIntProperty(fieldInfo, nuiElement);
                else if (valueType == typeof(string))
                    return new NuiSimpleStringProperty(fieldInfo, nuiElement);
                else if (valueType == typeof(float?))
                    return new NuiSimpleNullableFloatProperty(fieldInfo, nuiElement);
                else if (valueType == typeof(float))
                    return new NuiSimpleFloatProperty(fieldInfo, nuiElement);
                else if (valueType == typeof(NuiScrollbars))
                    return new NuiScrollSelectProperty(fieldInfo, nuiElement);
                else if (valueType == typeof(NuiDirection))
                    return new NuiDirectionSelectProperty(fieldInfo, nuiElement);
            }
            else
            {
                if (valueType == typeof(string))
                    return new NuiBindStringProperty(fieldInfo, nuiElement);
                else if (valueType == typeof(bool))
                    return new NuiBindBoolProperty(fieldInfo, nuiElement);
                else if (valueType == typeof(bool?))
                    return new NuiBindBoolNullableProperty(fieldInfo, nuiElement);
                else if (valueType == typeof(int))
                    return new NuiBindIntProperty(fieldInfo, nuiElement);
                else if (valueType == typeof(float))
                    return new NuiBindFloatProperty(fieldInfo, nuiElement);
                else if (valueType == typeof(NuiGeometry))
                    return new NuiBindGeometryProperty(fieldInfo, nuiElement);
                else if (valueType == typeof(NuiColor))
                    return new NuiBindColorProperty(fieldInfo, nuiElement);
                else if (valueType == typeof(NuiAspect))
                    return new NuiAspectSelectProperty(fieldInfo, nuiElement);
                else if (valueType == typeof(NuiVAlign))
                    return new NuiVAlignSelectProperty(fieldInfo, nuiElement);
                else if (valueType == typeof(NuiHAlign))
                    return new NuiHAlignSelectProperty(fieldInfo, nuiElement);
            }
            return new ErrorProperty<string>(fieldInfo, nuiElement);
        }
    }
}
