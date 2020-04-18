namespace Treynessen.UI
{
    public partial class Buttons
    {
        public string this[int rowId, int columnId] => buttons[rowId - 1][columnId - 1];

        public string this[int buttonNum]
        {
            get
            {
                (int rowId, int columnId) = GetButtonId(buttonNum);
                return buttons[rowId][columnId];
            }
        }
    }
}