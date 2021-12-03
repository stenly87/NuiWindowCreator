using NuiWindowCreator.NuiElements;
using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace NuiWindowCreator.NuiProperties
{
    public class NuiEnumSelectProperty<T> : NuiProperty where T : Enum
    {
        public string Name { get => fieldInfo.Name; }
        public List<T> Values { get; private set; }
        public T SelectedValue
        {
            get => (T)fieldInfo.GetValue(nuiElement);
            set
            {
                fieldInfo.SetValue(nuiElement, value);
            }
        }

        private FieldInfo fieldInfo;
        private INui nuiElement;

        public NuiEnumSelectProperty(FieldInfo fieldInfo, INui nuiElement)
        {
            Values = Enum.GetValues(typeof(T)).
                AsQueryable().
                Cast<T>().
                ToList();
            this.fieldInfo = fieldInfo;
            this.nuiElement = nuiElement;
        }
    }
}