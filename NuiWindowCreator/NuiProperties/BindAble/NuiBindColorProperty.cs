using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
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
            }
        }

        public string BindVar
        {
            get => bindVar.bind;
            set => bindVar.bind = value;
        }
        private BindValue bindVar = new BindValue { bind = "bind_color" };
        public string Name { get => fieldInfo.Name; }
        NuiColor Color;

        public byte A
        {
            get => Color.a;
            set
            {
                Color.a = value;
                fieldInfo.SetValue(nuiElement, Color);
                SignalChanged();
            }
        }
        public byte R
        {
            get => Color.r;
            set
            {
                Color.r = value;
                fieldInfo.SetValue(nuiElement, Color);
                SignalChanged();
            }
        }
        public byte G
        {
            get => Color.g;
            set
            {
                Color.g = value;
                fieldInfo.SetValue(nuiElement, Color);
                SignalChanged();
            }
        }
        public byte B
        {
            get => Color.b;
            set
            {
                Color.b = value;
                fieldInfo.SetValue(nuiElement, Color);
                SignalChanged();
            }
        }

        public NuiBindColorProperty(FieldInfo fieldInfo, INui nuiElement)
        {
            this.fieldInfo = fieldInfo;
            this.nuiElement = nuiElement;
            if (fieldInfo.GetValue(nuiElement) != null)
                Color = (NuiColor)fieldInfo.GetValue(nuiElement);
            else
                Color = new NuiColor();
        }
    }
}