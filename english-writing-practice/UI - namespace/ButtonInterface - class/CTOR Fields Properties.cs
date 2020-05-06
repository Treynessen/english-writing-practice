using System;

namespace Treynessen.UI
{
    public partial class ButtonInterface : IUserInterface
    {
        private Func<string> getTitle;
        private bool stopped = false;
        private ConsoleKey? leftKey, rightKey, upKey, downKey, enterKey;
        private ConsoleColor unselectedButton_textColor = IUserInterface.DefaultTextColor;
        private ConsoleColor unselectedButton_selectionColor = IUserInterface.DefaultBackgroundColor;
        private ConsoleColor selectedButton_textColor = ConsoleColor.White;
        private ConsoleColor selectedText_selectionColor = ConsoleColor.DarkMagenta;
        private Buttons buttons;
        private int verticalPosition = 1, horizontalPosition = 1;
        private Func<bool> withSoundEffect;
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
            get => (verticalPosition, horizontalPosition);
            set
            {
                if (!buttons.VerticalLineExists(value.Item1))
                {
                    throw new ArgumentException("Vertical position is incorrect");
                }
                else if (value.Item2 < 1 || value.Item2 > buttons.GetHorizontalButtonCount(value.Item1))
                {
                    throw new ArgumentException("Horizontal position is incorrect");
                }
                (verticalPosition, horizontalPosition) = value;
                UpdateInterface();
            }
        }
        public Button Target => buttons[Position];

        public event EventHandler OnPressingEnter;
        public event EventHandler OnPressedEnter;

        public ButtonInterface(Buttons buttons, ControlKeyContainer controlKeyContainer,
            Func<string> getTitle, Func<bool> withSoundEffect,
            string headerText = null, string footerText = null)
        {
            leftKey = controlKeyContainer.LeftKey;
            rightKey = controlKeyContainer.RightKey;
            upKey = controlKeyContainer.UpKey;
            downKey = controlKeyContainer.DownKey;
            enterKey = controlKeyContainer.EnterKey;
            this.getTitle = getTitle;
            if (buttons == null) throw new ArgumentException("Button container can't be null");
            this.buttons = buttons;
            this.withSoundEffect = withSoundEffect;
            this.headerText = headerText;
            this.footerText = footerText;
            Console.CursorVisible = false;
            Console.ForegroundColor = unselectedButton_textColor;
            Console.BackgroundColor = unselectedButton_selectionColor;
        }
    }
}