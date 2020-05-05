namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetPreviousVerticalLineId(int verticalLineId)
        {
            return verticalLineId <= 1 ? verticalLineCount : verticalLineId - 1;
        }
    }
}