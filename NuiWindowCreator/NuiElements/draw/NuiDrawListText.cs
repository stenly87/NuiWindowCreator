using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiDrawListText : NuiDrawListItem
    {
        [GuiProperty(typeof(NuiBindGeometryProperty))]
        [NuiBindable(typeof(NuiGeometry))]
        public object rect;
        [GuiProperty(typeof(NuiBindStringProperty))]
        [NuiBindable(typeof(string))]
        public object text;
        public NuiDrawListText()
        {
            type = 4;
            fill = null;
            line_thickness = null;
            rect = new NuiGeometry(0, 0, 10, 10);
        }
    }
}
