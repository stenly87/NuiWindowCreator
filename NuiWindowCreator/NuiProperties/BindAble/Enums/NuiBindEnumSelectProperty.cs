﻿using NuiWindowCreator.NuiElements;
using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("JsonInt()")]
    public class NuiBindEnumSelectProperty<T> : NuiProperty where T : Enum
    {
        public string Name { get => fieldInfo.Name; }
        public List<T> Values { get; private set; }
        public T SelectedValue
        {
            get => (T)fieldInfo.GetValue(nuiElement);
            set
            {
                notBindValue = value;
                fieldInfo.SetValue(nuiElement, value);
            }
        }

        private bool isBind;
        public bool IsBind
        {
            get => isBind;
            set
            {
                isBind = value;
                fieldInfo.SetValue(nuiElement, isBind ? (object)bindVar : notBindValue);
                SignalChanged(nameof(BindVar));
            }
        }

        public string BindVar
        {
            get => bindVar.bind;
            set => bindVar.bind = value;
        }
        private BindValue bindVar;

        private FieldInfo fieldInfo;
        private INui nuiElement;
        private T notBindValue;

        public NuiBindEnumSelectProperty(FieldInfo fieldInfo, INui nuiElement, string description) : base(description)
        {
            Values = Enum.GetValues(typeof(T)).
                AsQueryable().
                Cast<T>().
                ToList();
            this.fieldInfo = fieldInfo;
            this.nuiElement = nuiElement;
            bindVar = new BindValue { bind = "bind_" + Name };

            notBindValue = (T)fieldInfo.GetValue(nuiElement);
        }
    }
}