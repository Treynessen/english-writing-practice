using System;

namespace Treynessen.UI
{
    public partial class ButtonInterface : IUserInterface
    {
        Func<string> getName;
        private ConsoleKey? leftKey, rightKey, upKey, downKey, enterKey;
        private ConsoleColor unselectedButton_textColor = ConsoleColor.DarkRed;
        private ConsoleColor unselectedButton_selectionColor = ConsoleColor.White;
        private ConsoleColor selectedButton_textColor = ConsoleColor.White;
        private ConsoleColor selectedText_selectionColor = ConsoleColor.DarkMagenta;
        private Buttons buttons;
        private int verticalOperationNum = 1, horizontalOperationNum = 1;
        private Func<bool> soundEffect;
        private string headerText, footerText;

        public event Func<bool> StopAfterClickedEnterKey;

        public ButtonInterface(Buttons buttons, ControlKeyContainer controlKeyContainer, 
            Func<string> getName, Func<bool> soundEffect, 
            string headerText = null, string footerText = null)
        {
            leftKey = controlKeyContainer.LeftKey;
            rightKey = controlKeyContainer.RightKey;
            upKey = controlKeyContainer.UpKey;
            downKey = controlKeyContainer.DownKey;
            enterKey = controlKeyContainer.EnterKey;
            this.getName = getName;
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