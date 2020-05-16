using System;

namespace Treynessen.UI
{
    public partial class ButtonInterface
    {
        private void UpdateInterface()
        {
            Console.Clear();
            Console.Title = getTitle();
            if (getHeaderText != null)
            {
                Console.WriteLine(getHeaderText());
            }
            for (int rowId = 1; rowId <= buttons.VerticalLineCount; ++rowId)
            {
                for (int columnId = 1; columnId <= buttons.GetHorizontalButtonCount(rowId); ++columnId)
                {
                    if (columnId > 1)
                    {
                        Console.Write("   ");
                    }
                    if (rowId == verticalPosition && columnId == horizontalPosition)
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
            if (getFooterText != null)
            {
                Console.WriteLine(getFooterText());
            }
        }
    }
}