using System;
using System.Threading.Tasks;

namespace Treynessen.UI
{
    public partial class ButtonInterface
    {
        private Task ControlAsync()
        {
            return Task.Run(() =>
            {
                while (!stopped)
                {
                    bool callUpdateInterface = false;
                    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
                    if ((buttons.VerticalControlAvailable() && VerticalKeyPressed(pressedKeyInfo))
                    || (buttons.HorizontalControlAvailable(verticalPosition) && HorizontalKeyPressed(pressedKeyInfo)))
                    {
                        if (withSoundEffect()) Console.Beep(2000, 80);
                        if (upKey.HasValue && pressedKeyInfo.Key == upKey.Value)
                        {
                            verticalPosition = buttons.GetPreviousVerticalLineId(verticalPosition);
                            if (horizontalPosition > buttons.GetHorizontalButtonCount(verticalPosition))
                            {
                                horizontalPosition = buttons.GetHorizontalButtonCount(verticalPosition);
                            }
                        }
                        else if (downKey.HasValue && pressedKeyInfo.Key == downKey.Value)
                        {
                            verticalPosition = buttons.GetNextVerticalLineId(verticalPosition);
                            if (horizontalPosition > buttons.GetHorizontalButtonCount(verticalPosition))
                            {
                                horizontalPosition = buttons.GetHorizontalButtonCount(verticalPosition);
                            }
                        }
                        else if (leftKey.HasValue && pressedKeyInfo.Key == leftKey.Value)
                        {
                            horizontalPosition = buttons.GetPreviousHorizontalButtonId(verticalPosition, horizontalPosition);
                        }
                        else if (rightKey.HasValue && pressedKeyInfo.Key == rightKey.Value)
                        {
                            horizontalPosition = buttons.GetNextHorizontalButtonId(verticalPosition, horizontalPosition);
                        }
                        callUpdateInterface = true;
                    }
                    else if (enterKey.HasValue && pressedKeyInfo.Key == enterKey.Value)
                    {
                        Button pressedButton = Target;
                        if (withSoundEffect() && pressedButton.Active) Console.Beep(700, 80);
                        OnPressingEnter?.Invoke(this, EventArgs.Empty);
                        pressedButton.Press();
                        OnPressedEnter?.Invoke(this, EventArgs.Empty);
                        callUpdateInterface = !stopped;
                    }
                    if (callUpdateInterface) UpdateInterface();
                }
            });
        }
    }
}