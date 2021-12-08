using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiCheck : NuiElement
    {
        [NuiUnic()]
        [GuiProperty(typeof(NuiBindBoolProperty))]
        [NuiBindable(typeof(bool))]
        public new object value = new BindValue { bind = "bind_checked" };
        public NuiCheck()
        {
            type = "check";
            label = "Переключатель";
        }
    }
}
