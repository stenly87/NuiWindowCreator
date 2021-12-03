namespace NuiWindowCreator.NuiElements
{
    public class NuiButtonSelect : NuiElement
    {
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
