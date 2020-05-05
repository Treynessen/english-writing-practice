using System;
using System.Collections.Generic;

namespace Treynessen.UI
{
    public partial class Buttons
    {
        public void AddButton(int verticalLineId, int horizontalButtonId, Button button)
        {
            if (verticalLineId < 1 || verticalLineId > verticalLineCount + 1)
            {
                throw new IndexOutOfRangeException("Incorrect vertical position Id");
            }
            else if (horizontalButtonId < 1
                || (verticalLineId != verticalLineCount + 1 && horizontalButtonId > GetHorizontalButtonCount(verticalLineId) + 1)
                || (verticalLineId == verticalLineCount + 1 && horizontalButtonId > 1))
            {
                throw new IndexOutOfRangeException("Incorrect horizontal position Id");
            }
            if (verticalLineId == verticalLineCount + 1)
            {
                buttonGrid.AddLast(new LinkedList<Button>());
                buttonGrid.Last.Value.AddLast(button);
                ++verticalLineCount;
            }
            else
            {
                int currentVerticalLineId = 1;
                foreach (var buttonLine in buttonGrid)
                {
                    if (currentVerticalLineId == verticalLineId)
                    {
                        if (horizontalButtonId == 1)
                        {
                            buttonLine.AddFirst(button);
                        }
                        else if (horizontalButtonId == buttonLine.Count + 1)
                        {
                            buttonLine.AddLast(button);
                        }
                        else
                        {
                            int currentHorizontalButtonId = 1;
                            for (var buttonNode = buttonLine.First; buttonNode != null; buttonNode = buttonNode.Next)
                            {
                                if (currentHorizontalButtonId == horizontalButtonId)
                                {
                                    buttonLine.AddBefore(buttonNode, button);
                                    break;
                                }
                                ++currentHorizontalButtonId;
                            }
                        }
                        break;
                    }
                    ++currentVerticalLineId;
                }
            }
            ++buttonCount;
        }

        public void AddButton((int, int) buttonPosition, Button button)
        {
            AddButton(buttonPosition.Item1, buttonPosition.Item2, button);
        }

        public void AddButton(int buttonId, Button button)
        {
            if (buttonId < 1 || buttonId > buttonCount + 1)
            {
                throw new IndexOutOfRangeException("Incorrect button id");
            }
            if (buttonId == 1)
            {
                if (buttonGrid.First == null)
                {
                    buttonGrid.AddLast(new LinkedList<Button>());
                    ++verticalLineCount;
                }
                buttonGrid.First.Value.AddFirst(button);
            }
            else if (buttonId == buttonCount + 1)
            {
                if (buttonGrid.First == null)
                {
                    buttonGrid.AddLast(new LinkedList<Button>());
                    ++verticalLineCount;
                }
                buttonGrid.Last.Value.AddLast(button);
            }
            else
            {
                int currentButtonId = 0;
                foreach (var buttonLine in buttonGrid)
                {
                    if (currentButtonId + buttonLine.Count >= buttonId)
                    {
                        for (var buttonNode = buttonLine.First; buttonNode != null; buttonNode = buttonNode.Next)
                        {
                            ++currentButtonId;
                            if (currentButtonId == buttonId)
                            {
                                buttonLine.AddBefore(buttonNode, button);
                                break;
                            }
                        }
                        break;
                    }
                    currentButtonId += buttonLine.Count;
                }
            }
            ++buttonCount;
        }
    }
}