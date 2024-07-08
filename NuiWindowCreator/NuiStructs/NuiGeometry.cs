using System;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiGeometry : NuiStruct
    {
        public float x { get; set; } 
        public float y { get; set; }
        public float h { get; set; } 
        public float w { get; set; }

        public NuiGeometry(float x, float y, float h, float w)
        {
            this.x = x;
            this.y = y;
            this.h = h;
            this.w = w;
        }

        internal bool IsZero()
        {
            return x == 0 && y == 0 && h == 0 && w == 0;
        }
    }
}
