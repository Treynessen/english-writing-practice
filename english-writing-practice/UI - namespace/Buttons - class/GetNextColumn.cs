namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetNextColumnId(int currentRowId, int currentColumnId)
        {
            int columnCount = GetColumnCount(currentRowId);
            return currentColumnId >= columnCount ? 1 : currentColumnId + 1;
        }
    }
}