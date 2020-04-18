namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetPreviousRowId(int currentRowId)
        {
            return currentRowId <= 1 ? GetRowCount() : currentRowId - 1;
        }
    }
}