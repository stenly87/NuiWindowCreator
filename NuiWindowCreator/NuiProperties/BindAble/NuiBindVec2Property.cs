using NuiWindowCreator.NuiElements;
using NuiWindowCreator.NuiStructs;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    [JsonBindString("jNuiVec2")]
    internal class NuiBindVec2Property : NuiProperty
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
                fieldInfo.SetValue(nuiElement, isBind ? (object)bindVar : Vector);
                SignalChanged(nameof(BindVar));
            }
        }

        public string BindVar
        {
            get => bindVar.bind;
            set => bindVar.bind = value;
        }
        private BindValue bindVar = new BindValue { bind = "bind_vec2" };
        public string Name { get => fieldInfo.Name; }
        NuiVec2 Vector;

        public float X
        {
            get => Vector.x;
            set
            {
                Vector.x = value;
                fieldInfo.SetValue(nuiElement, Vector);
            }
        }
        public float Y
        {
            get => Vector.y;
            set
            {
                Vector.y = value;
                fieldInfo.SetValue(nuiElement, Vector);
            }
        }

        public NuiBindVec2Property(FieldInfo fieldInfo, INui nuiElement, string description = null) : base(description)
        {
            this.fieldInfo = fieldInfo;
            this.nuiElement = nuiElement;

            Vector = (NuiVec2)fieldInfo.GetValue(nuiElement);
        }
    }
}