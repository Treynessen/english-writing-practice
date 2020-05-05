using System;

namespace Treynessen.UI
{
    public partial class Buttons
    {
        public (int, int) GetButtonPosition(int buttonId)
        {
            if (ButtonExists(buttonId))
            {
                int currentVerticalLineId = 1;
                int count = 0;
                for (var node = buttonGrid.First; node != null; node = node.Next)
                {
                    if (count + node.Value.Count >= buttonId)
                    {
                        return (currentVerticalLineId, buttonId - count);
                    }
                    count += node.Value.Count;
                    ++currentVerticalLineId;
                }
            }
            throw new IndexOutOfRangeException($"Button №{buttonId} doesn't exist");
        }

        public (int, int) GetButtonPosition(Button button)
        {
            int verticalLineId = 1;
            foreach (var buttonLine in buttonGrid)
            {
                int horizontalButtonId = 1;
                foreach (var _button in buttonLine)
                {
                    if (ReferenceEquals(_button, button))
                    {
                        return (verticalLineId, horizontalButtonId);
                    }
                    ++horizontalButtonId;
                }
                ++verticalLineId;
            }
            throw new IndexOutOfRangeException($"Button not found");
        }
    }
}