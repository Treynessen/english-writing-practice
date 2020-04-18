namespace Treynessen.UI
{
    public partial class Buttons
    {
        public bool HorizontalControlAvailable(int rowId) => buttons[rowId - 1].Length > 1;
    }
}