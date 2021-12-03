using NuiWindowCreator.NuiElements;
using System.Reflection;

namespace NuiWindowCreator.NuiProperties
{
    internal class NuiBindGeometryProperty : NuiProperty
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
                fieldInfo.SetValue(nuiElement, isBind ? (object)bindVar : Geometry);
                SignalChanged(nameof(BindVar));
            }
        }

        public string BindVar { 
            get => bindVar.bind; 
            set => bindVar.bind = value; 
        }
        private BindValue bindVar = new BindValue { bind = "bind_geometry" };
        public string Name { get => fieldInfo.Name; }
        NuiGeometry Geometry;

        public float X
        {
            get => Geometry.x;
            set
            {
                Geometry.x = value;
                fieldInfo.SetValue(nuiElement, Geometry);
            }
        }
        public float Y
        {
            get => Geometry.y;
            set
            {
                Geometry.y = value;
                fieldInfo.SetValue(nuiElement, Geometry);
            }
        }
        public float H
        {
            get => Geometry.h;
            set
            {
                Geometry.h = value;
                fieldInfo.SetValue(nuiElement, Geometry);
            }
        }
        public float W
        {
            get => Geometry.w;
            set
            {
                Geometry.w = value;
                fieldInfo.SetValue(nuiElement, Geometry);
            }
        }

        public NuiBindGeometryProperty(FieldInfo fieldInfo, INui nuiElement)
        {
            this.fieldInfo = fieldInfo;
            this.nuiElement = nuiElement;

            Geometry = (NuiGeometry)fieldInfo.GetValue(nuiElement);
        }
    }
}