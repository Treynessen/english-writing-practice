namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetNextVerticalLineId(int currentVerticalLineId)
        {
            return currentVerticalLineId >= buttons.Length ? 1 : currentVerticalLineId + 1;
        }
    }
}