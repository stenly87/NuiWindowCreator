using NuiWindowCreator.NuiProperties;
using System;

namespace NuiWindowCreator.NuiElements
{
    [Serializable]
    public class NuiWindow : INui
    {
        [NuiIgnoreProperty]
        public INui root;
        [GuiProperty(typeof(NuiBindStringProperty))]
        [NuiBindable(typeof(string))]
        public object title;
        [NuiIgnoreProperty]
        public int version = 1;
        [GuiProperty(typeof(NuiSimpleBoolProperty))]
        [NuiBindable(typeof(bool))]
        public object border;
        [GuiProperty(typeof(NuiSimpleBoolProperty))]
        [NuiBindable(typeof(bool))]
        public object closable;
        [GuiProperty(typeof(NuiSimpleBoolProperty))]
        [NuiBindable(typeof(bool))]
        public object collapsed;
        [GuiProperty(typeof(NuiSimpleBoolProperty))]
        [NuiBindable(typeof(bool))]
        public object resizable;
        [GuiProperty(typeof(NuiSimpleBoolProperty))]
        [NuiBindable(typeof(bool))]
        public object transparent;
        [GuiProperty(typeof(NuiBindGeometryProperty))]
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
