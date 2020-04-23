namespace Treynessen.UI
{
    public partial class Buttons
    {
        public Button this[int verticalLineId, int horizontalButtonId] => buttons[verticalLineId - 1][horizontalButtonId - 1];

        public Button this[int buttonNum]
        {
            get
            {
                (int verticalLineId, int horizontalButtonId) = GetButtonId(buttonNum);
                return this[verticalLineId, horizontalButtonId];
            }
        }
    }
}