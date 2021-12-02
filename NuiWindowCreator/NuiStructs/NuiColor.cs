namespace NuiWindowCreator.NuiElements
{
    public class NuiColor : NuiStruct
    {
        public byte a { get; set; }
        public byte r { get; set; }
        public byte g { get; set; }
        public byte b { get; set; }

        public NuiColor(byte a, byte r, byte g, byte b)
        {
            this.a = a;
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public NuiColor()
        {
            a = r = g = b = 255;
        }
    }
}