namespace Treynessen.UI
{
    public partial class Buttons
    {
        public bool ButtonExists(int buttonId)
        {
            if (buttonId < 1 || buttonId > buttonCount)
            {
                return false;
            }
            return true;
        }

        public bool ButtonExists(int verticalLineId, int horizontalButtonId)
        {
            if (!VerticalLineExists(verticalLineId))
            {
                return false;
            }
            else if (horizontalButtonId < 1 || horizontalButtonId > GetHorizontalButtonCount(verticalLineId))
            {
                return false;
            }
            return true;
        }

        public bool ButtonExists((int, int) buttonPosition) => ButtonExists(buttonPosition.Item1, buttonPosition.Item2);

        public bool ButtonExists(Button button)
        {
            foreach (var buttonLine in buttonGrid)
            {
                foreach (var _button in buttonLine)
                {
                    if (ReferenceEquals(button, _button))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}