namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetPreviousColumnId(int currentRowId, int currentColumnId)
        {
            int columnCount = GetColumnCount(currentRowId);
            return currentColumnId <= 1 ? columnCount : currentColumnId - 1;
        }
    }
}