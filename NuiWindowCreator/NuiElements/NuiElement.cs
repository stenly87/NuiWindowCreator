using NuiWindowCreator.NuiProperties;
using System;
using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiElement : INui
    {
        [GuiProperty(typeof(NuiSimpleStringProperty), "Tag the given element with a id.\r\nOnly tagged elements will send events to the server.")]
        public string id;
        [NuiIgnoreProperty]
        public string type;
        [GuiProperty(typeof(NuiBindStringProperty))]
        [NuiBindable(typeof(string))]
        public object label = "";
        [NuiUnic()]
        [GuiProperty(typeof(NuiBindStringProperty))]
        [NuiBindable(typeof(string))]
        public object value;
        [GuiProperty(typeof(NuiBindStringProperty), "Tooltips show on mouse hover.")]
        [NuiBindable(typeof(string))]
        public object tooltip;
        [GuiProperty(typeof(NuiBindStringProperty), "Tooltips for disabled elements show on mouse hover.")]
        [NuiBindable(typeof(string))]
        public object disabled_tooltip;

        [GuiProperty(typeof(NuiSimpleNullableFloatProperty), "Element width in pixels (strength=required). Float")]
        public float? width;
        [GuiProperty(typeof(NuiSimpleNullableFloatProperty), "Height in pixels (strength=required). Float")]
        public float? height;
        [GuiProperty(typeof(NuiSimpleNullableFloatProperty), "Ratio of x/y. Float")]
        public float? aspect;
        [GuiProperty(typeof(NuiSimpleNullableFloatProperty), "Set a margin on the widget. The margin is the spacing outside of the widget. Float")]
        public float? margin;
        [GuiProperty(typeof(NuiSimpleNullableFloatProperty), "Set padding on the widget. The margin is the spacing inside of the widget. Float")]
        public float? padding;

        [GuiProperty(typeof(NuiBindBoolNullableProperty), "Disabled elements are non-interactive and greyed out. (True/False)")]
        [NuiBindable(typeof(bool?))]
        public object enabled;
        [GuiProperty(typeof(NuiBindBoolNullableProperty), "Invisible elements do not render at all, but still take up layout space. (True/False)")]
        [NuiBindable(typeof(bool?))]
        public object visible;

        [GuiProperty(typeof(NuiBindStringProperty), "Override the font used for this element. The font and it's properties needs to be listed in\r\nnui_skin.tml, as all fonts are pre-baked into a texture atlas at content load.")]
        [NuiBindable(typeof(string))]
        public object font;

        [GuiProperty(typeof(NuiBindBoolNullableProperty), "Encouraged elements have a breathing animated glow inside of it. (True/False)")]
        [NuiBindable(typeof(bool?))]
        public object encouraged;

        [GuiProperty(typeof(NuiBindColorProperty), "Style the foreground color of a widget or window title. This is dependent on the widget\r\nin question and only supports solid/full colors right now (no texture skinning).\r\nFor example, labels would style their text color; progress bars would style the bar.\r\nTo color the window title text, pass the result of NuiWindow into this function as jElem.")]
        [NuiBindable(typeof(NuiColor))]
        public object foreground_color;

        [NuiIgnoreProperty]
        public List<INui> draw_list;
        [GuiProperty(typeof(NuiBindBoolNullableProperty), "Constrain painted elements to widget bounds. Use it with NuiDrawList*. (True/False)")]
        [NuiBindable(typeof(bool?))]
        public object draw_list_scissor;

        internal void AddDrawItem(INui element)
        {
            if (draw_list == null)
                draw_list = new List<INui>();
            draw_list.Add(element);
        }

        internal void RemoveDrawItem(INui element)
        {
            draw_list.Remove(element);
            if (draw_list.Count == 0)
                draw_list = null;
        }
    }
}
