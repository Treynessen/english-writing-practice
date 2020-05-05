namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetPreviousHorizontalButtonId(int verticalLineId, int horizontalButtonId)
        {
            int horizontalButtonCount = GetHorizontalButtonCount(verticalLineId);
            return horizontalButtonId <= 1 ? horizontalButtonCount : horizontalButtonId - 1;
        }

        public int GetPreviousHorizontalButtonId((int, int) buttonPosition) 
            => GetPreviousHorizontalButtonId(buttonPosition.Item1, buttonPosition.Item2);
    }
}