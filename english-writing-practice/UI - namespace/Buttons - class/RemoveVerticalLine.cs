using System;

namespace Treynessen.UI
{
    public partial class Buttons
    {
        public void RemoveVerticalLine(int verticalLineId)
        {
            if (verticalLineId > GetVerticalLineCount())
            {
                throw new ArgumentException($"Vertical line №{verticalLineId} not found");
            }
            Button[][] buttons = new Button[GetVerticalLineCount() - 1][];
            for (int thisButtonsVerticalLineIt = 0, newButtonsVerticalLineIt = 0;
                thisButtonsVerticalLineIt < GetVerticalLineCount();
                ++thisButtonsVerticalLineIt, ++newButtonsVerticalLineIt)
            {
                if (thisButtonsVerticalLineIt == verticalLineId - 1)
                {
                    --newButtonsVerticalLineIt;
                    continue;
                }
                buttons[newButtonsVerticalLineIt] = this.buttons[thisButtonsVerticalLineIt];
            }
            this.buttons = buttons;
        }
    }
}