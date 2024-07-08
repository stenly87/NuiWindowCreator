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
        [GuiProperty(typeof(NuiBindBoolProperty))]
        [NuiBindable(typeof(bool))]
        public object border;
        [GuiProperty(typeof(NuiBindBoolProperty))]
        [NuiBindable(typeof(bool))]
        public object closable;
        [GuiProperty(typeof(NuiBindBoolNullableProperty))]
        [NuiBindable(typeof(bool))]
        public object collapsed;
        [GuiProperty(typeof(NuiBindBoolProperty))]
        [NuiBindable(typeof(bool))]
        public object resizable;
        [GuiProperty(typeof(NuiBindBoolProperty))]
        [NuiBindable(typeof(bool))]
        public object transparent;
        [GuiProperty(typeof(NuiBindGeometryProperty))]
        [NuiBindable(typeof(NuiGeometry))]
        public object geometry;
        [GuiProperty(typeof(NuiBindBoolProperty))]
        [NuiBindable(typeof(bool))]
        public object accepts_input;

        [GuiProperty(typeof(NuiBindGeometryProperty))]
        [NuiBindable(typeof(NuiGeometry))]
        public object edge_constraint;
        [GuiProperty(typeof(NuiBindGeometryProperty))]
        [NuiBindable(typeof(NuiGeometry))]
        public object size_constraint;
        [GuiProperty(typeof(NuiBindStringProperty))]
        [NuiBindable(typeof(string))]
        public object font;

        public NuiWindow()
        {
            geometry = new NuiGeometry(-1, -1, 300, 300);
            title = "caption window";
            accepts_input = true;
            border = true;
            closable = true;
            collapsed = null;
            resizable = false;
            transparent = false;
            root = new NullElement();
        }
    }
}
