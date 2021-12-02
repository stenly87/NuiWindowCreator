using NuiWindowCreator.NuiElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NuiWindowCreator.NuiProperties
{
    public class NuiBindProperty <T>: NuiProperty
    {
        TypeConverter converter;
        private FieldInfo fieldInfo;
        private INui nuiElement;
        public string Name { get => fieldInfo.Name; }
        public bool IsBind
        {
            get => isBind;
            set
            {
                isBind = value;
                Value = IsBind ? (object)bindValue : localValue;
            }
        }

        BindValue bindValue = new BindValue();
        T localValue = default;
        private bool isBind;

        public object Value
        {
            get => IsBind ? (object)bindValue.bind : localValue;
            set
            {
                if (Value == null)
                    return;
                if (IsBind)
                {
                    bindValue.bind = value.ToString();
                    fieldInfo.SetValue(nuiElement, bindValue);
                }
                else
                {
                    try
                    {
                        localValue = (T)converter.ConvertFromString(value.ToString());
                        fieldInfo.SetValue(nuiElement, localValue);
                    }
                    catch
                    {
                    }
                }
                SignalChanged();
            }
        }

        public NuiBindProperty(FieldInfo fieldInfo, INui nuiElement)
        {
            this.fieldInfo = fieldInfo;
            this.nuiElement = nuiElement;
            converter = TypeDescriptor.GetConverter(typeof(T));
        }
    }
}
