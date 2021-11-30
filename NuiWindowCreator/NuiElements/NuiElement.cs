namespace NuiWindowCreator.NuiElements
{
    public class NuiElement : INui
    {
        public string id;
        public string type;
        public object label;
        public object value;
        public object tooltip;

        public float? width;
        public float? height;
        public float? aspect;
        public float? margin;
        public float? padding;

        public bool? enabled;
        public bool? visible;
    }
}