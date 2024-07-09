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
        [GuiProperty(typeof(NuiBindBoolProperty), "Render or not border")]
        [NuiBindable(typeof(bool))]
        public object border;
        [GuiProperty(typeof(NuiBindBoolProperty), "You must provide a way to close the window if you set this to FALSE.\r\nFor better UX, handle the window \"closed\" event.")]
        [NuiBindable(typeof(bool))]
        public object closable;
        [GuiProperty(typeof(NuiBindBoolNullableProperty), "Set to a static value JsonBool(FALSE) to disable collapsing.\r\nSet to JsonNull() to let user collapse without binding.\r\nFor better UX, leave collapsing on.")]
        [NuiBindable(typeof(bool))]
        public object collapsed;
        [GuiProperty(typeof(NuiBindBoolProperty), "Set to JsonBool(TRUE) or JsonNull() to let user resize without binding.")]
        [NuiBindable(typeof(bool))]
        public object resizable;
        [GuiProperty(typeof(NuiBindBoolProperty), "Render or not background")]
        [NuiBindable(typeof(bool))]
        public object transparent;
        [GuiProperty(typeof(NuiBindGeometryProperty), "Set x and/or y to -1.0 to center the window on that axis\r\nSet x and/or y to -2.0 to position the window's top left at the mouse cursor's position of that axis\r\nSet x and/or y to -3.0 to center the window on the mouse cursor's position of that axis")]
        [NuiBindable(typeof(NuiGeometry))]
        public object geometry;
        [GuiProperty(typeof(NuiBindBoolProperty), "Set JsonBool(FALSE) to disable all input.\r\nAll hover, clicks and keypresses will fall through.")]
        [NuiBindable(typeof(bool))]
        public object accepts_input;

        [GuiProperty(typeof(NuiBindGeometryProperty), "Prevents a form from being rendered within the specified margins.\r\nSet x to left margin, y to top margin, w to right margin, h to bottom margin.\r\nSet any individual constraint to 0.0 to ignore that constraint.")]
        [NuiBindable(typeof(NuiGeometry))]
        public object edge_constraint;
        [GuiProperty(typeof(NuiBindGeometryProperty), "Constrains minimum and maximum size of window.\r\nSet x to minimum width, y to minimum height, w to maximum width, h to maximum height.\r\nSet any individual constraint to 0.0 to ignore that constraint.")]
        [NuiBindable(typeof(NuiGeometry))]
        public object size_constraint;
        [GuiProperty(typeof(NuiBindStringProperty), "Override the font used for this element. The font and it's properties needs to be listed in\r\nnui_skin.tml, as all fonts are pre-baked into a texture atlas at content load.")]
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
