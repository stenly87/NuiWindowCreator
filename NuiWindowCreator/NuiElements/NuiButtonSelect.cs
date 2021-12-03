using NuiWindowCreator.NuiProperties;

namespace NuiWindowCreator.NuiElements
{
    [System.Serializable]
    public class NuiButtonSelect : NuiElement
    {
        [GuiProperty(typeof(NuiBindIntProperty))]
        [NuiBindable(typeof(int))]
        public new object value;
        public NuiButtonSelect()
        {
            type = "button_select";
            label = "Кнопка";
            value = new BindValue {  bind = "bind_selected"};
        }
    }
}
