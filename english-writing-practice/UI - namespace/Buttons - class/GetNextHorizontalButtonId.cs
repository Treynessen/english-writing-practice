namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetNextHorizontalButtonId(int verticalLineId, int horizontalButtonId)
        {
            int horizontalButtonCount = GetHorizontalButtonCount(verticalLineId);
            return horizontalButtonId >= horizontalButtonCount ? 1 : horizontalButtonId + 1;
        }

        public int GetNextHorizontalButtonId((int, int) buttonPosition) 
            => GetNextHorizontalButtonId(buttonPosition.Item1, buttonPosition.Item2);
    }
}