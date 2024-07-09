using NuiWindowCreator.NuiElements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("jsonArray")]
    internal class NuiArrayFloatPairsSelectProperty : NuiProperty
    {
        private FieldInfo fieldInfo;
        private INui nuiElement;
        private bool isBind;

        public string Name { get => fieldInfo.Name; }
        public ObservableCollection<FloatPair> Values
        {
            get => values;
            set
            {
                values = value;
                localValue = ConvertToFloatArray(values);
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
        private List<float> localValue;
        private ObservableCollection<FloatPair> values = new ObservableCollection<FloatPair>();

        public NuiArrayFloatPairsSelectProperty(FieldInfo fieldInfo, INui nuiElement, string description = null) : base(description)
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
                    localValue = (List<float>)fieldInfo.GetValue(nuiElement);
                    Values = ConvertToFloatPairs(localValue);
                }
            }
            else
            {
                bindValue = new BindValue();
                localValue = new List<float>();
            }
        }

        public void UpdateValues()
        {
            localValue = ConvertToFloatArray(values);
            fieldInfo.SetValue(nuiElement, localValue);
        }

        private ObservableCollection<FloatPair> ConvertToFloatPairs(List<float> localValue)
        {
            ObservableCollection<FloatPair> result = new ObservableCollection<FloatPair>();
            for (int i = 0; i < localValue.Count; i+=2)
            {
                var row = new FloatPair { Start = localValue[i], End = localValue[i + 1] };
                result.Add(row);
            }
            return result;
        }

        private List<float> ConvertToFloatArray(ObservableCollection<FloatPair> values)
        {
            List<float> result = new List<float>();
            foreach (var val in values)
            {
                result.Add(val.Start);
                result.Add(val.End);
            }
            return result;
        }
    }

    internal class FloatPair
    {
        public float Start { get; set; }
        public float End { get; set; }
    }
}