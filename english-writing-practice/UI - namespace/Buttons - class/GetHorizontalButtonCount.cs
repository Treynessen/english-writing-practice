using System;

namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetHorizontalButtonCount(int verticalLineId)
        {
            if (VerticalLineExists(verticalLineId))
            {
                int currentVerticalLineId = 1;
                foreach (var verticalLine in buttonGrid)
                {
                    if (currentVerticalLineId == verticalLineId)
                    {
                        return verticalLine.Count;
                    }
                    ++currentVerticalLineId;
                }
            }
            throw new IndexOutOfRangeException($"Vertical line №{verticalLineId} doesn't exist");
        }
    }
}