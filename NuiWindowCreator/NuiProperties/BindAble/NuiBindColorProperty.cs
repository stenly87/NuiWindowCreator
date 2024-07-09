using NuiWindowCreator.NuiElements;
using System;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("NuiColor(r, g, b)")]
    internal class NuiBindColorProperty : NuiProperty
    {
        private FieldInfo fieldInfo;
        private INui nuiElement;
        private bool isBind;

        public bool IsBind
        {
            get => isBind;
            set
            {
                isBind = value;
                fieldInfo.SetValue(nuiElement, isBind ? (object)bindVar : Color);
                SignalChanged(nameof(BindVar));
                SignalChanged(nameof(IsBind));
            }
        }

        public string BindVar
        {
            get => bindVar.bind;
            set
            {
                bindVar.bind = value;
                SignalChanged();
            }
        }
        private BindValue bindVar = new BindValue { bind = "bind_color" };
        public string Name { get => fieldInfo.Name; }
        NuiColor Color;

        public byte? A
        {
            get => Color?.a;
            set
            {
                Color.a = (byte)value;
                fieldInfo.SetValue(nuiElement, Color);
                SignalChanged();
            }
        }
        public byte? R
        {
            get => Color?.r;
            set
            {
                Color.r = (byte)value;
                fieldInfo.SetValue(nuiElement, Color);
                SignalChanged();
            }
        }
        public byte? G
        {
            get => Color?.g;
            set
            {
                Color.g = (byte)value;
                fieldInfo.SetValue(nuiElement, Color);
                SignalChanged();
            }
        }
        public byte? B
        {
            get => Color?.b;
            set
            {
                Color.b = (byte)value;
                fieldInfo.SetValue(nuiElement, Color);
                SignalChanged();
            }
        }

        public NuiBindColorProperty(FieldInfo fieldInfo, INui nuiElement, string description = null) : base(description)
        {
            this.fieldInfo = fieldInfo;
            this.nuiElement = nuiElement;
            Color = new NuiColor();
            if (fieldInfo.GetValue(nuiElement) != null)
            {
                if (fieldInfo.GetValue(nuiElement) is BindValue bind)
                {
                    bindVar = bind;
                    IsBind = true;
                }
                else
                    Color = (NuiColor)fieldInfo.GetValue(nuiElement);
            }
        }

        internal void Clear()
        {
            Color = null;
            IsBind = false;
        }
    }
}