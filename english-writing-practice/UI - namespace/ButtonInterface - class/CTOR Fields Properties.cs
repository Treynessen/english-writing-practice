using System;

namespace Treynessen.UI
{
    public partial class ButtonInterface : IUserInterface
    {
        Func<string> getTitle;
        private ConsoleKey? leftKey, rightKey, upKey, downKey, enterKey;
        private ConsoleColor unselectedButton_textColor = IUserInterface.DefaultTextColor;
        private ConsoleColor unselectedButton_selectionColor = IUserInterface.DefaultBackgroundColor;
        private ConsoleColor selectedButton_textColor = ConsoleColor.White;
        private ConsoleColor selectedText_selectionColor = ConsoleColor.DarkMagenta;
        private Buttons buttons;
        private int verticalOperationNum = 1, horizontalOperationNum = 1;
        private Func<bool> soundEffect;
        private string headerText, footerText;

        public Buttons Buttons
        {
            get => buttons;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Button container can't equal null");
                }
                buttons = value;
            }
        }
        public (int, int) Position
        {
            get => (verticalOperationNum, horizontalOperationNum);
            set
            {
                if (value.Item1 < 1 || value.Item1 > buttons.GetVerticalLineCount())
                {
                    throw new ArgumentException("Vertical position is incorrect");
                }
                else if (value.Item2 < 1 || value.Item2 > buttons.GetHorizontalButtonCount(value.Item1))
                {
                    throw new ArgumentException("Horizontal position is incorrect");
                }
                (verticalOperationNum, horizontalOperationNum) = value;
                UpdateInterface();
            }
        }

        public event Func<bool> StopAfterClickedEnterKey;

        public ButtonInterface(Buttons buttons, ControlKeyContainer controlKeyContainer,
            Func<string> getTitle, Func<bool> soundEffect,
            string headerText = null, string footerText = null)
        {
            leftKey = controlKeyContainer.LeftKey;
            rightKey = controlKeyContainer.RightKey;
            upKey = controlKeyContainer.UpKey;
            downKey = controlKeyContainer.DownKey;
            enterKey = controlKeyContainer.EnterKey;
            this.getTitle = getTitle;
            this.buttons = buttons;
            this.soundEffect = soundEffect;
            this.headerText = headerText;
            this.footerText = footerText;
            Console.CursorVisible = false;
            Console.ForegroundColor = unselectedButton_textColor;
            Console.BackgroundColor = unselectedButton_selectionColor;
        }
    }
}