using System;

namespace Treynessen.UI
{
    public partial class UserInterface
    {
        private void UpdateInterface()
        {
            Console.Clear();
            Console.Title = $"{programName} - {localization[currentSection.ToString() + ":SectionName"]}";
            string headerText = localization[currentSection.ToString() + ":header"];
            string footerText = localization[currentSection.ToString() + ":footer"];
            if (!string.IsNullOrEmpty(headerText))
            {
                Console.WriteLine(headerText);
            }
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
                        Console.Write(buttons[rowId, columnId].Name);
                        Console.ForegroundColor = defaultTextColor;
                        Console.BackgroundColor = defaultTextBackgroundColor;
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