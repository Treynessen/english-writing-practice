using System;

namespace Treynessen.UI
{
    public partial class Buttons
    {
        public void RemoveVerticalLine(int verticalLineId)
        {
            if (!VerticalLineExists(verticalLineId))
            {
                throw new ArgumentException($"Vertical line №{verticalLineId} doesn't exist");
            }
            int currentVerticalLineId = 1;
            for (var buttonLineNode = buttonGrid.First; buttonLineNode != null; buttonLineNode = buttonLineNode.Next)
            {
                if (currentVerticalLineId == verticalLineId)
                {
                    buttonCount -= buttonLineNode.Value.Count;
                    buttonGrid.Remove(buttonLineNode);
                    --verticalLineCount;
                    break;
                }
                ++currentVerticalLineId;
            }
        }
    }
}