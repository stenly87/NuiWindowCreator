using NuiWindowCreator.NuiElements;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NuiWindowCreator
{
    public class NuiPropertyInfo : INotifyPropertyChanged
    {
        public NuiPropertyInfo(string name, object v, FieldInfo s, INui nuiElement)
        {
            Name = name;
            Value = v;
            fieldInfo = s;
            iNui = nuiElement;
            bindAttribute = (NuiBindableAttribute[])fieldInfo?.GetCustomAttributes(typeof(NuiBindableAttribute), false);
            if(IsBindable)
                typeConverter = TypeDescriptor.GetConverter(bindAttribute.First().TargetType);
        }
        public string Name { get; set; }

        NuiStruct oldValue;
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
                if (IsBind)
                {
                    if (Value is NuiStruct nuiStruct)
                        oldValue = nuiStruct;
                    value = new BindValue { bind = value.ToString() };
                }
                else if (IsBindable && typeConverter != null)
                {
                    if (oldValue != null)
                        value = oldValue;
                    else
                    {
                        var str = value.ToString().Replace("\"", "");
                        value = typeConverter.ConvertFromString(str);
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
