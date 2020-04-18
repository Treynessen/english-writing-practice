using System;
using System.Threading.Tasks;

namespace Treynessen.UI
{
    public partial class UserInterface
    {
        public Task Start(bool innerWaiting = true)
        {
            stopped = false;
            controlTask = Task.Run(() =>
            {
                currentSection = Section.Menu;
                OpenSection();
                while (!stopped)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if ((verticalControlAvailable && (keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.DownArrow))
                    || (horizontalControlAvailable && buttons.GetColumnCount(verticalOperationNum) > 1 && (keyInfo.Key == ConsoleKey.LeftArrow || keyInfo.Key == ConsoleKey.RightArrow)))
                    {
                        if (soundEffect) Console.Beep(5000, 80);
                        if (keyInfo.Key == ConsoleKey.UpArrow)
                        {
                            verticalOperationNum = buttons.GetPreviousRowId(verticalOperationNum);
                        }
                        else if (keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            verticalOperationNum = buttons.GetNextRowId(verticalOperationNum);
                        }
                        else if (keyInfo.Key == ConsoleKey.LeftArrow)
                        {
                            horizontalOperationNum = buttons.GetPreviousColumnId(verticalOperationNum, horizontalOperationNum);
                        }
                        else if (keyInfo.Key == ConsoleKey.RightArrow)
                        {
                            horizontalOperationNum = buttons.GetNextColumnId(verticalOperationNum, horizontalOperationNum);
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