using System;
using System.Threading.Tasks;

namespace Treynessen.UI
{
    public partial class ButtonInterface
    {
        private Task ControlAsync()
        {
            bool stopped = false;
            return Task.Run(() =>
            {
                while (!stopped)
                {
                    bool callUpdateMethod = false;
                    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
                    if ((buttons.VerticalControlAvailable() && VerticalKeyPressed(pressedKeyInfo))
                    || (buttons.HorizontalControlAvailable(verticalOperationNum) && HorizontalKeyPressed(pressedKeyInfo)))
                    {
                        if (soundEffect()) Console.Beep(5000, 80);
                        if (upKey.HasValue && pressedKeyInfo.Key == upKey.Value)
                        {
                            verticalOperationNum = buttons.GetPreviousVerticalLineId(verticalOperationNum);
                        }
                        else if (downKey.HasValue && pressedKeyInfo.Key == downKey.Value)
                        {
                            verticalOperationNum = buttons.GetNextVerticalLineId(verticalOperationNum);
                        }
                        else if (leftKey.HasValue && pressedKeyInfo.Key == leftKey.Value)
                        {
                            horizontalOperationNum = buttons.GetPreviousHorizontalButtonId(verticalOperationNum, horizontalOperationNum);
                        }
                        else if (rightKey.HasValue && pressedKeyInfo.Key == rightKey.Value)
                        {
                            horizontalOperationNum = buttons.GetNextHorizontalButtonId(verticalOperationNum, horizontalOperationNum);
                        }
                        callUpdateMethod = true;
                    }
                    else if (enterKey.HasValue && pressedKeyInfo.Key == enterKey.Value)
                    {
                        if (soundEffect()) Console.Beep(700, 80);
                        buttons[verticalOperationNum, horizontalOperationNum].Press();
                        if (StopAfterClickedEnterKey != null)
                        {
                            stopped = StopAfterClickedEnterKey();
                        }
                        if (!stopped)
                        {
                            callUpdateMethod = true;
                        }
                    }
                    if (callUpdateMethod) UpdateInterface();
                }
            });
        }
    }
}