using System;

namespace Treynessen.UI
{
    public partial class Buttons
    {
        public Button this[int verticalLineId, int horizontalButtonId]
        {
            get
            {
                if (VerticalLineExists(verticalLineId))
                {
                    int currentVerticalLineId = 1;
                    foreach (var buttonLine in buttonGrid)
                    {
                        if (currentVerticalLineId == verticalLineId)
                        {
                            int currentHorizontalButtonId = 1;
                            foreach (var button in buttonLine)
                            {
                                if (currentHorizontalButtonId == horizontalButtonId)
                                {
                                    return button;
                                }
                                ++currentHorizontalButtonId;
                            }
                            break;
                        }
                        ++currentVerticalLineId;
                    }
                }
                throw new IndexOutOfRangeException($"Button[{verticalLineId};{horizontalButtonId}] doesn't exist");
            }
        }

        public Button this[(int, int) buttonPosition] => this[buttonPosition.Item1, buttonPosition.Item2];

        public Button this[int buttonId]
        {
            get
            {
                if (ButtonExists(buttonId))
                {
                    int currentButtonId = 0;
                    foreach (var buttonLine in buttonGrid)
                    {
                        if (currentButtonId + buttonLine.Count >= buttonId)
                        {
                            foreach (var button in buttonLine)
                            {
                                ++currentButtonId;
                                if (currentButtonId == buttonId)
                                {
                                    return button;
                                }
                            }
                            break;
                        }
                        currentButtonId += buttonLine.Count;
                    }
                }
                throw new IndexOutOfRangeException($"Button №{buttonId} doesn't exist");
            }
        }
    }
}