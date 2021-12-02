using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    public class NuiSimpleProperty<T> : NuiProperty
    {
        private FieldInfo fieldInfo;
        private INui nuiElement;

        public string Name { get => fieldInfo.Name; }
        public T Value
        {
            get => (T)fieldInfo.GetValue(nuiElement);
            set
            {
                fieldInfo.SetValue(nuiElement, value);
                SignalChanged();
            }
        }

        public NuiSimpleProperty(FieldInfo fieldInfo, INui nuiElement)
        {
            this.fieldInfo = fieldInfo;
            this.nuiElement = nuiElement;
        }
    }
}