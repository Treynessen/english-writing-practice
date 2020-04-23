namespace Treynessen.UI
{
    public partial class Buttons
    {
        public bool HorizontalControlAvailable(int verticalLineId) => buttons[verticalLineId - 1].Length > 1;
    }
}