namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetNextHorizontalButtonId(int currentVerticalLineId, int currentHorizontalButtonId)
        {
            int columnCount = GetHorizontalButtonCount(currentVerticalLineId);
            return currentHorizontalButtonId >= columnCount ? 1 : currentHorizontalButtonId + 1;
        }
    }
}