namespace Treynessen.UI
{
    public partial class Buttons
    {
        public Button this[int rowId, int columnId] => buttons[rowId - 1][columnId - 1];

        public Button this[int buttonNum]
        {
            get
            {
                (int rowId, int columnId) = GetButtonId(buttonNum);
                return this[rowId, columnId];
            }
        }
    }
}