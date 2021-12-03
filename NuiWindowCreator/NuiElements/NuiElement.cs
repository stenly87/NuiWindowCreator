namespace NuiWindowCreator.NuiElements
{
    public class NuiElement : INui
    {
        public string id;
        [NuiIgnoreProperty]
        public string type;
        [NuiBindable(typeof(string))]
        public object label = "";
        [NuiBindable(typeof(string))]
        public object value;
        [NuiBindable(typeof(string))]
        public object tooltip;

        public float? width;
        public float? height;
        public float? aspect;
        public float? margin;
        public float? padding;

        [NuiBindable(typeof(bool?))]
        public object enabled;
        [NuiBindable(typeof(bool?))]
        public object visible;
    }
}
