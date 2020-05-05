namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetNextVerticalLineId(int verticalLineId)
        {
            return verticalLineId >= verticalLineCount ? 1 : verticalLineId + 1;
        }
    }
}