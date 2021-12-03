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
    }
}
