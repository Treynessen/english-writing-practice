using System;

namespace Treynessen.UI
{
    public partial class UserInterface
    {
        private void ShowInterface()
        {
            Console.Clear();
            Console.Title = $"{programName} - {localization[currentSection.ToString() + ":SectionName"]}";
            for (int rowId = 1; rowId <= buttons.GetRowCount(); ++rowId)
            {
                for (int columnId = 1; columnId <= buttons.GetColumnCount(rowId); ++columnId)
                {
                    if (columnId > 1)
                    {
                        Console.Write("   ");
                    }
                    if (rowId == verticalOperationNum && columnId == horizontalOperationNum)
                    {
                        Console.ForegroundColor = selectedTextColor;
                        Console.BackgroundColor = selectedTextBackgroundColor;
                        Console.Write(buttons[rowId, columnId]);
                        Console.ForegroundColor = defaultTextColor;
                        Console.BackgroundColor = defaultTextBackgroundColor;
                    }
                    else Console.Write(buttons[rowId, columnId]);
                }
                Console.WriteLine();
            }
        }
    }
}