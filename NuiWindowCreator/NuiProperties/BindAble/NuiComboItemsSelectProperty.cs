using NuiWindowCreator.NuiElements;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NuiWindowCreator.NuiProperties
{
    public class NuiComboItemsSelectProperty : NuiProperty
    {
        private FieldInfo fieldInfo;
        private INui nuiElement;
        private bool isBind;

        public string Name { get => fieldInfo.Name; }
        public ObservableCollection<StringEntry> Values
        {
            get => values;
            set
            {
                values = value;
                int count = 0;
                localValue = values.Select(s => new object[] { s.Value, count++ }).ToList();
                fieldInfo.SetValue(nuiElement, localValue);
                SignalChanged();
            }
        }
        public bool IsBind
        {
            get => isBind;
            set
            {
                isBind = value;
                SignalChanged();
                fieldInfo.SetValue(nuiElement, isBind ? (object)bindValue : localValue);
                SignalChanged(nameof(BindVar));
            }
        }
        public string BindVar
        {
            get => bindValue.bind;
            set => bindValue.bind = value;
        }
        private BindValue bindValue = new BindValue { bind = "bind_array" };
        private List<object[]> localValue;
        private ObservableCollection<StringEntry> values = new ObservableCollection<StringEntry>();

        public NuiComboItemsSelectProperty(FieldInfo fieldInfo, INui nuiElement)
        {
            this.fieldInfo = fieldInfo;
            this.nuiElement = nuiElement;

            if (fieldInfo.GetValue(nuiElement) != null)
            {
                if (fieldInfo.GetValue(nuiElement) is BindValue)
                {
                    isBind = true;
                    bindValue = (BindValue)fieldInfo.GetValue(nuiElement);
                }
                else
                {
                    localValue = (List<object[]>)fieldInfo.GetValue(nuiElement);
                    Values = new ObservableCollection<StringEntry>(localValue.Select(s => new StringEntry { Value = s[0].ToString() }));
                }
            }
            else
            {
                bindValue = new BindValue();
                localValue = new List<object[]>();
            }
        }
    }

    public class StringEntry : INotifyPropertyChanged
    {
        private string value;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public string Value
        {
            get => value;
            set
            {
                this.value = value;
                SignalChanged();
            }
        }
    }
}