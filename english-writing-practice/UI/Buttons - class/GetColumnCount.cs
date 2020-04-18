namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetColumnCount(int currentRowId)
        {
            return buttons[currentRowId - 1].Length;
        }
    }
}