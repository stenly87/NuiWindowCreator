using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiProgress : NuiElement
    {
        [GuiProperty(typeof(NuiBindFloatProperty))]
        [NuiBindable(typeof(float))]
        public new object value;
        public NuiProgress()
        {
            type = "progress";
            value = new BindValue { bind = "progress_value" };
        }
    }
}
