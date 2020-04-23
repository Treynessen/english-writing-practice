namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetHorizontalButtonCount(int currentVerticalLineId)
        {
            return buttons[currentVerticalLineId - 1].Length;
        }
    }
}