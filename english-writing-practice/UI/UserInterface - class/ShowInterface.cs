using System;

namespace Treynessen.UI
{
    public partial class UserInterface
    {
        private void ShowInterface()
        {
            Console.Clear();
            Console.Title = $"{programName} - {localization[currentSection.ToString() + ":SectionName"]}";
            int count = 1;
            foreach (var button in sectionButtons)
            {
                if (count == operationNum)
                {
                    Console.ForegroundColor = selectedTextColor;
                    Console.BackgroundColor = selectedTextBackgroundColor;
                    Console.Write("> ");
                }
                else
                {
                    Console.ForegroundColor = defaultTextColor;
                    Console.BackgroundColor = defaultTextBackgroundColor;
                }
                Console.WriteLine(button);
                if (count == operationNum)
                {
                    Console.ForegroundColor = defaultTextColor;
                    Console.BackgroundColor = defaultTextBackgroundColor;
                }
                ++count;
            }
        }
    }
}