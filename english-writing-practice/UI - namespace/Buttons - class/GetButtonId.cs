using System;

namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetButtonId(int verticalLineId, int horizontalButtonId)
        {
            if (VerticalLineExists(verticalLineId))
            {
                int count = 0;
                int currentVerticalLineId = 1;
                foreach (var buttonLine in buttonGrid)
                {
                    if (verticalLineId == currentVerticalLineId)
                    {
                        if (horizontalButtonId > buttonLine.Count) break;
                        return count + horizontalButtonId;
                    }
                    count += buttonLine.Count;
                    ++currentVerticalLineId;
                }
            }
            throw new IndexOutOfRangeException($"Button[{verticalLineId};{horizontalButtonId}] doesn't exist");
        }

        public int GetButtonId((int, int) buttonPosition) => GetButtonId(buttonPosition.Item1, buttonPosition.Item2);

        public int GetButtonId(Button button)
        {
            int count = 1;
            foreach (var buttonLine in buttonGrid)
            {
                foreach (var _button in buttonLine)
                {
                    if (ReferenceEquals(_button, button))
                    {
                        return count;
                    }
                    ++count;
                }
            }
            throw new IndexOutOfRangeException($"Button not found");
        }
    }
}