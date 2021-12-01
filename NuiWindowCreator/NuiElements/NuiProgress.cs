namespace NuiWindowCreator.NuiElements
{
    public class NuiProgress : NuiElement
    {
        [NuiBindable(typeof(float))]
        public new object value;
        public NuiProgress()
        {
            type = "progress";
            value = new BindValue { bind = "progress_value" };
        }
    }
}
