using System;

namespace Treynessen.UI
{
    public partial class Buttons
    {
        public void RemoveButton(int verticalLineId, int horizontalButtonId)
        {
            if (!ButtonExists(verticalLineId, horizontalButtonId))
            {
                throw new ArgumentException($"Button[{verticalLineId};{horizontalButtonId}] doesn't exist");
            }
            int currentVerticalLineId = 1;
            for (var verticalLineNode = buttonGrid.First; verticalLineNode != null; verticalLineNode = verticalLineNode.Next)
            {
                if (currentVerticalLineId == verticalLineId)
                {
                    int currentHorizontalButtonId = 1;
                    for (var buttonNode = verticalLineNode.Value.First; buttonNode != null; buttonNode = buttonNode.Next)
                    {
                        if (currentHorizontalButtonId == horizontalButtonId)
                        {
                            verticalLineNode.Value.Remove(buttonNode);
                            if (verticalLineNode.Value.Count == 0)
                            {
                                buttonGrid.Remove(verticalLineNode);
                                --verticalLineCount;
                            }
                            --buttonCount;
                            return;
                        }
                        ++currentHorizontalButtonId;
                    }
                    break;
                }
                ++currentVerticalLineId;
            }
        }

        public void RemoveButton((int, int) buttonPosition)
        {
            RemoveButton(buttonPosition.Item1, buttonPosition.Item2);
        }

        public void RemoveButton(int buttonId)
        {
            if (!ButtonExists(buttonId))
            {
                throw new IndexOutOfRangeException($"Button №{buttonId} doesn't exist");
            }
            int currentButtonId = 0;
            for (var verticalLineNode = buttonGrid.First; verticalLineNode != null; verticalLineNode = verticalLineNode.Next)
            {
                if (currentButtonId + verticalLineNode.Value.Count >= buttonId)
                {
                    for (var buttonNode = verticalLineNode.Value.First; buttonNode != null; buttonNode = buttonNode.Next)
                    {
                        ++currentButtonId;
                        if (currentButtonId == buttonId)
                        {
                            verticalLineNode.Value.Remove(buttonNode);
                            if (verticalLineNode.Value.Count == 0)
                            {
                                buttonGrid.Remove(verticalLineNode);
                                --verticalLineCount;
                            }
                            --buttonCount;
                            return;
                        }
                    }
                    break;
                }
                currentButtonId += verticalLineNode.Value.Count;
            }
        }

        public void RemoveButton(Button button)
        {
            for (var buttonLineNode = buttonGrid.First; buttonLineNode != null; buttonLineNode = buttonLineNode.Next)
            {
                for (var buttonNode = buttonLineNode.Value.First; buttonNode != null; buttonNode = buttonNode.Next)
                {
                    if (ReferenceEquals(buttonNode.Value, button))
                    {
                        buttonLineNode.Value.Remove(buttonNode);
                        --buttonCount;
                        if (buttonLineNode.Value.Count == 0)
                        {
                            buttonGrid.Remove(buttonLineNode);
                            --verticalLineCount;
                        }
                        return;
                    }
                }
            }
        }
    }
}