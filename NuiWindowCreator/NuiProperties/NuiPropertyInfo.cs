using NuiWindowCreator.NuiElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NuiWindowCreator
{
    public class NuiPropertyInfo : INotifyPropertyChanged, IDataErrorInfo
    {
        public NuiPropertyInfo(string name, object v, FieldInfo s, INui nuiElement)
        {
            Name = name;
            Value = v;
            fieldInfo = s;
            iNui = nuiElement;
            bindAttribute = (NuiBindableAttribute[])fieldInfo?.GetCustomAttributes(typeof(NuiBindableAttribute), false);
            if (IsBindable)
                typeConverter = TypeDescriptor.GetConverter(bindAttribute.First().TargetType);
            else 
                typeConverter = TypeDescriptor.GetConverter(fieldInfo.FieldType);
            IsBind = v is BindValue;
        }
        public string Name { get; set; }

        object oldValue;
        bool lastSetError = false;
        public object Value
        {
            get
            {
                var val = fieldInfo?.GetValue(iNui);
                if (val is BindValue bind)
                    return bind.bind;
                return val;
            }
            set
            {
                lastSetError = false;
                if (value != null)
                {
                    if (IsBind)
                    {
                        if (Value is NuiStruct || Value is Enum || value.ToString().Contains("System."))
                        {
                            oldValue = Value;
                            value = "bind_name";
                        }
                        value = new BindValue { bind = value.ToString() };
                    }
                    else if (IsBindable && oldValue != null)
                    {
                        value = oldValue;
                    }
                    if (value is string && typeConverter != null)
                    {
                        var str = value.ToString().Replace("\"", "");
                        try
                        {
                            value = typeConverter.ConvertFromString(str);
                        }
                        catch
                        {
                            lastSetError = true;
                            return;
                        }
                    }
                }
                fieldInfo?.SetValue(iNui, value);
                SignalChanged();
            }
        }
        public bool IsBindable { get => bindAttribute?.Length > 0; }

        public bool IsBind
        {
            get => isBind;
            set
            {
                isBind = value;
                Value = Value;
            }
        }

        public string Error => throw new System.NotImplementedException();

        public string this[string columnName]
        {
            get {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Value":
                        if (!IsBind && IsBindable && lastSetError)
                            error = $"Invalid Value for {Name}";
                        break;
                }
                return error;
            }
        }

        public FieldInfo fieldInfo;
        public INui iNui;
        private bool isBind;
        private NuiBindableAttribute[] bindAttribute;
        TypeConverter typeConverter;

        public event PropertyChangedEventHandler PropertyChanged;
        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
