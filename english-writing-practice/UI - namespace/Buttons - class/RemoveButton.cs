using System;

namespace Treynessen.UI
{
    public partial class Buttons
    {
        public void RemoveButton(int verticalLineId, int horizontalButtonId)
        {
            if (verticalLineId > GetVerticalLineCount() || horizontalButtonId > GetHorizontalButtonCount(verticalLineId))
            {
                throw new ArgumentException($"Button[{verticalLineId};{horizontalButtonId}] not found");
            }
            if (GetHorizontalButtonCount(verticalLineId) <= 1)
            {
                RemoveVerticalLine(verticalLineId);
            }
            else
            {
                Button[][] buttons = new Button[GetVerticalLineCount()][];
                for (int verticalLineIt = 0; verticalLineIt < GetVerticalLineCount(); ++verticalLineIt)
                {
                    if (verticalLineIt == verticalLineId - 1)
                    {
                        for (int thisButtonsHorizontalButtonIt = 0, newButtonsHorizontalButtonIt = 0;
                            thisButtonsHorizontalButtonIt < GetHorizontalButtonCount(verticalLineIt);
                            ++thisButtonsHorizontalButtonIt, ++newButtonsHorizontalButtonIt)
                        {
                            if (thisButtonsHorizontalButtonIt == horizontalButtonId - 1)
                            {
                                --newButtonsHorizontalButtonIt;
                                continue;
                            }
                            buttons[verticalLineIt][newButtonsHorizontalButtonIt] = this.buttons[verticalLineIt][thisButtonsHorizontalButtonIt];
                        }
                    }
                    else
                    {
                        buttons[verticalLineIt] = this.buttons[verticalLineIt];
                    }
                }
                this.buttons = buttons;
            }
        }
    }
}