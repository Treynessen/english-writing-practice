namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetNextRowId(int currentRowId)
        {
            return currentRowId >= buttons.Length ? 1 : currentRowId + 1;
        }
    }
}