namespace Treynessen.UI
{
    public partial class Buttons
    {
        public bool HorizontalControlAvailable(int verticalLineId) => GetHorizontalButtonCount(verticalLineId) > 1;
    }
}