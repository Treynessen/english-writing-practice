namespace Treynessen.UI
{
    public partial class Buttons
    {
        public static Buttons Union(params Buttons[] buttonContainers)
        {
            Buttons buttons = new Buttons();
            foreach (var container in buttonContainers)
            {
                buttons.Union(container);
            }
            return buttons;
        }
    }
}