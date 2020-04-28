using System.Linq;
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
                for (int verticalLineId = 0; verticalLineId < buttons.Length; ++verticalLineId)
                {
                    count += buttons[verticalLineId].Length;
                }
                return count;
            }
        }

        public Buttons(LinkedList<LinkedList<string>> buttonList)
        {
            buttons = new Button[buttonList.Count][];
            int verticalLineId = 0;
            foreach (var horizontalButtons in buttonList)
            {
                buttons[verticalLineId] = new Button[horizontalButtons.Count];
                int horizontalButtonId = 0;
                foreach (var buttonName in horizontalButtons)
                {
                    buttons[verticalLineId][horizontalButtonId++] = new Button(buttonName);
                }
                ++verticalLineId;
            }
        }

        public Buttons(IEnumerable<LinkedList<Button>> buttonList)
        {
            buttons = new Button[buttonList.Count()][];
            int verticalLineId = 0;
            foreach (var horizontalButtons in buttonList)
            {
                buttons[verticalLineId] = new Button[horizontalButtons.Count];
                int horizontalButtonId = 0;
                foreach (var button in horizontalButtons)
                {
                    buttons[verticalLineId][horizontalButtonId++] = button;
                }
                ++verticalLineId;
            }
        }

        public Buttons(LinkedList<LinkedList<Button>> buttonList) : this(buttonList as IEnumerable<LinkedList<Button>>)
        {
        }
    }
}