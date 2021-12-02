using NuiWindowCreator.NuiElements;
using System;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    internal class ErrorProperty<T> : NuiProperty
    {
        private FieldInfo fieldInfo;
        private INui nuiElement;

        public string Name { get => fieldInfo.Name; set { } }
        public T Value { get => throw new Exception(); set { } }

        public ErrorProperty(FieldInfo fieldInfo, INui nuiElement)
        {
            this.fieldInfo = fieldInfo;
            this.nuiElement = nuiElement;
        }
    }
}