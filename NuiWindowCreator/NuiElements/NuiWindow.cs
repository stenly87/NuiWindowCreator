namespace NuiWindowCreator.NuiElements
{
    public class NuiWindow : INui
    {
        [NuiIgnoreProperty]
        public INui root;

        [NuiBindable(typeof(string))]
        public object title;
        [NuiIgnoreProperty]
        public int version = 1;
        [NuiBindable(typeof(bool))]
        public object border;
        [NuiBindable(typeof(bool))]
        public object closable;
        [NuiBindable(typeof(bool))]
        public object collapsed;
        [NuiBindable(typeof(bool))]
        public object resizable;
        [NuiBindable(typeof(bool))]
        public object transparent;
        [NuiBindable(typeof(NuiGeometry))]
        public object geometry;

        public NuiWindow()
        {
            geometry = new NuiGeometry(-1, -1, 300, 300);
            title = "Заголовок окна";
            border = true;
            closable = true;
            collapsed = false;
            resizable = true;
            transparent = false;
            root = new NullElement();
        }
    }
}
