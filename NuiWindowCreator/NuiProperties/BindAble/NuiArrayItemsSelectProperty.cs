using NuiWindowCreator.NuiElements;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    internal class NuiArrayItemsSelectProperty : NuiProperty
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
                localValue = values.Select(s => s.Value).ToList();
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
        private List<string> localValue;
        private ObservableCollection<StringEntry> values = new ObservableCollection<StringEntry>();

        public NuiArrayItemsSelectProperty(FieldInfo fieldInfo, INui nuiElement)
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
                    localValue = (List<string>)fieldInfo.GetValue(nuiElement);
                    Values = new ObservableCollection<StringEntry>(localValue.Select(s => new StringEntry { Value = s[0].ToString() }));
                }
            }
            else
            {
                bindValue = new BindValue();
                localValue = new List<string>();
            }
        }
    }
}