namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetPreviousVerticalLineId(int currentVerticalLineId)
        {
            return currentVerticalLineId <= 1 ? GetVerticalLineCount() : currentVerticalLineId - 1;
        }
    }
}