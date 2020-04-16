using System;
using System.Threading.Tasks;

namespace Treynessen.UI
{
    public partial class UserInterface
    {
        public Task Start(bool innerWaiting = true)
        {
            stopped = false;
            operationNum = 1;
            controlTask = Task.Run(() =>
            {
                currentSection = Section.Menu;
                BuildSectionButtons();
                ShowInterface();
                while (!stopped)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (keyInfo.Key == ConsoleKey.UpArrow)
                        {
                            operationNum = operationNum == 1 ? sectionButtons.Count : operationNum - 1;
                        }
                        else if (keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            operationNum = operationNum == sectionButtons.Count ? 1 : operationNum + 1;
                        }
                        ShowInterface();
                    }
                }
            });
            if (innerWaiting)
            {
                controlTask.Wait();
                return Task.CompletedTask;
            }
            else return controlTask;
        }
    }
}