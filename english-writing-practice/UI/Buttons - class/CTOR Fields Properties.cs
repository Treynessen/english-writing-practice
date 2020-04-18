using System.Collections.Generic;

namespace Treynessen.UI
{
    public partial class Buttons
    {
        private string[][] buttons;

        public Buttons(LinkedList<LinkedList<string>> buttonList)
        {
            buttons = new string[buttonList.Count][];
            int rowId = 0;
            foreach (var horizontalButtons in buttonList)
            {
                buttons[rowId] = new string[horizontalButtons.Count];
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