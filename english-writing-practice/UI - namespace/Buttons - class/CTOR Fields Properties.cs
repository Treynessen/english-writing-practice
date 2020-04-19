using System.Collections.Generic;

namespace Treynessen.UI
{
    public partial class Buttons
    {
        private Button[][] buttons;

        public int Count
        {
            get
            {
                int count = 0;
                for (int row = 0; row < buttons.Length; ++row)
                {
                    count += buttons[row].Length;
                }
                return count;
            }
        }

        public Buttons(LinkedList<LinkedList<string>> buttonList)
        {
            buttons = new Button[buttonList.Count][];
            int rowId = 0;
            foreach (var horizontalButtons in buttonList)
            {
                buttons[rowId] = new Button[horizontalButtons.Count];
                int columnId = 0;
                foreach (var buttonName in horizontalButtons)
                {
                    buttons[rowId][columnId++] = new Button(buttonName);
                }
                ++rowId;
            }
        }

        public Buttons(LinkedList<LinkedList<Button>> buttonList)
        {
            buttons = new Button[buttonList.Count][];
            int rowId = 0;
            foreach (var horizontalButtons in buttonList)
            {
                buttons[rowId] = new Button[horizontalButtons.Count];
                int columnId = 0;
                foreach (var button in horizontalButtons)
                {
                    buttons[rowId][columnId++] = button;
                }
                ++rowId;
            }
        }
    }
}