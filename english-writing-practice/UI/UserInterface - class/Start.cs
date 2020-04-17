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
                OpenSection();
                while (!stopped)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (soundEffect) Console.Beep(5000, 80);
                        if (keyInfo.Key == ConsoleKey.UpArrow)
                        {
                            operationNum = operationNum <= 1 ? sectionButtons.Count : operationNum - 1;
                        }
                        else if (keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            operationNum = operationNum >= sectionButtons.Count ? 1 : operationNum + 1;
                        }
                        ShowInterface();
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        if (soundEffect) Console.Beep(700, 80);
                        PressedButtonAction();
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