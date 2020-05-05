using System.Collections.Generic;

namespace Treynessen.UI
{
    public partial class Buttons
    {
        public void Union(Buttons buttons)
        {
            buttonCount += buttons.buttonCount;
            verticalLineCount += buttons.verticalLineCount;
            foreach (var buttonLine in buttons.buttonGrid)
            {
                buttonGrid.AddLast(buttonLine);
            }
        }

        public void Union(LinkedList<LinkedList<Button>> buttonGrid)
        {
            foreach (var buttonLine in buttonGrid)
            {
                this.buttonGrid.AddLast(buttonLine);
                ++verticalLineCount;
                buttonCount += buttonLine.Count;
            }
        }

        public void Union(LinkedList<LinkedList<string>> buttonNames)
        {
            foreach (var buttonLine in buttonNames)
            {
                buttonGrid.AddLast(new LinkedList<Button>());
                ++verticalLineCount;
                foreach (var buttonName in buttonLine)
                {
                    buttonGrid.Last.Value.AddLast(new Button(buttonName));
                    ++buttonCount;
                }
            }
        }
    }
}