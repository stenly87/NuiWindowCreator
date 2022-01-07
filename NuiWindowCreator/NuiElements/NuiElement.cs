using NuiWindowCreator.NuiProperties;
using System;
using System.Collections.Generic;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiElement : INui
    {
        [GuiProperty(typeof(NuiSimpleStringProperty))]
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
        [GuiProperty(typeof(NuiBindStringProperty))]
        [NuiBindable(typeof(string))]
        public object tooltip;

        [GuiProperty(typeof(NuiSimpleNullableFloatProperty))]
        public float? width;
        [GuiProperty(typeof(NuiSimpleNullableFloatProperty))]
        public float? height;
        [GuiProperty(typeof(NuiSimpleNullableFloatProperty))]
        public float? aspect;
        [GuiProperty(typeof(NuiSimpleNullableFloatProperty))]
        public float? margin;
        [GuiProperty(typeof(NuiSimpleNullableFloatProperty))]
        public float? padding;

        [GuiProperty(typeof(NuiBindBoolNullableProperty))]
        [NuiBindable(typeof(bool?))]
        public object enabled;
        [GuiProperty(typeof(NuiBindBoolNullableProperty))]
        [NuiBindable(typeof(bool?))]
        public object visible;

        [GuiProperty(typeof(NuiBindColorProperty))]
        [NuiBindable(typeof(NuiColor))]
        public object foreground_color;

        [NuiIgnoreProperty]
        public List<INui> draw_list;
        [GuiProperty(typeof(NuiBindBoolNullableProperty))]
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
