using System;

namespace Treynessen.UI
{
    public partial class ButtonInterface
    {
        private void UpdateInterface()
        {
            Console.Clear();
            Console.Title = getTitle();
            if (!string.IsNullOrEmpty(headerText))
            {
                Console.WriteLine(headerText);
            }
            for (int rowId = 1; rowId <= buttons.VerticalLineCount; ++rowId)
            {
                for (int columnId = 1; columnId <= buttons.GetHorizontalButtonCount(rowId); ++columnId)
                {
                    if (columnId > 1)
                    {
                        Console.Write("   ");
                    }
                    if (rowId == verticalOperationNum && columnId == horizontalOperationNum)
                    {
                        Console.ForegroundColor = selectedButton_textColor;
                        Console.BackgroundColor = selectedText_selectionColor;
                        Console.Write(buttons[rowId, columnId].Name);
                        Console.ForegroundColor = unselectedButton_textColor;
                        Console.BackgroundColor = unselectedButton_selectionColor;
                    }
                    else Console.Write(buttons[rowId, columnId].Name);
                }
                Console.WriteLine();
            }
            if (!string.IsNullOrEmpty(footerText))
            {
                Console.WriteLine(footerText);
            }
        }
    }
}