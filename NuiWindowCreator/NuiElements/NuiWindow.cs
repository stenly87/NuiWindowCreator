namespace NuiWindowCreator.NuiElements
{
    public class NuiWindow : INui
    {
        public NuiElement root;

        public object title;
        public int version = 1;
        public object border;
        public object closable;
        public object collapsed;
        public object resizable;
        public object transparent;

        public NuiGeometry geometry;

        public NuiWindow()
        {
            geometry = new NuiGeometry();
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
