namespace Treynessen.UI
{
    public partial class Buttons
    {
        public bool VerticalLineExists(int verticalLineId)
        {
            if (verticalLineId < 1 || verticalLineId > verticalLineCount)
            {
                return false;
            }
            return true;
        }
    }
}