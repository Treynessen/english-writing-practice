namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetPreviousHorizontalButtonId(int currentVerticalLineId, int currentHorizontalButtonId)
        {
            int columnCount = GetHorizontalButtonCount(currentVerticalLineId);
            return currentHorizontalButtonId <= 1 ? columnCount : currentHorizontalButtonId - 1;
        }
    }
}