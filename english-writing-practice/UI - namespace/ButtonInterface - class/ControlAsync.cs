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
                    bool callUpdateInterface = false;
                    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
                    if ((buttons.VerticalControlAvailable() && VerticalKeyPressed(pressedKeyInfo))
                    || (buttons.HorizontalControlAvailable(verticalOperationNum) && HorizontalKeyPressed(pressedKeyInfo)))
                    {
                        if (soundEffect()) Console.Beep(2000, 80);
                        if (upKey.HasValue && pressedKeyInfo.Key == upKey.Value)
                        {
                            verticalOperationNum = buttons.GetPreviousVerticalLineId(verticalOperationNum);
                            if (horizontalOperationNum > buttons.GetHorizontalButtonCount(verticalOperationNum))
                            {
                                horizontalOperationNum = buttons.GetHorizontalButtonCount(verticalOperationNum);
                            }
                        }
                        else if (downKey.HasValue && pressedKeyInfo.Key == downKey.Value)
                        {
                            verticalOperationNum = buttons.GetNextVerticalLineId(verticalOperationNum);
                            if (horizontalOperationNum > buttons.GetHorizontalButtonCount(verticalOperationNum))
                            {
                                horizontalOperationNum = buttons.GetHorizontalButtonCount(verticalOperationNum);
                            }
                        }
                        else if (leftKey.HasValue && pressedKeyInfo.Key == leftKey.Value)
                        {
                            horizontalOperationNum = buttons.GetPreviousHorizontalButtonId(verticalOperationNum, horizontalOperationNum);
                        }
                        else if (rightKey.HasValue && pressedKeyInfo.Key == rightKey.Value)
                        {
                            horizontalOperationNum = buttons.GetNextHorizontalButtonId(verticalOperationNum, horizontalOperationNum);
                        }
                        callUpdateInterface = true;
                    }
                    else if (enterKey.HasValue && pressedKeyInfo.Key == enterKey.Value)
                    {
                        if (soundEffect()) Console.Beep(700, 80);
                        buttons[verticalOperationNum, horizontalOperationNum].Press();
                        stopped = StopAfterClickedEnterKey == null ? true : StopAfterClickedEnterKey();
                        callUpdateInterface = stopped ? false : true;
                    }
                    if (callUpdateInterface) UpdateInterface();
                }
            });
        }
    }
}