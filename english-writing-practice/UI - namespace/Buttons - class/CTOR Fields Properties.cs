using System.Collections.Generic;

namespace Treynessen.UI
{
    public partial class Buttons
    {
        private LinkedList<LinkedList<Button>> buttonGrid;

        private int buttonCount = 0;
        private int verticalLineCount = 0;

        public int ButtonCount
        {
            get
            {
                if (buttonCount == 0)
                {
                    foreach (var buttonLine in buttonGrid)
                    {
                        buttonCount += buttonLine.Count;
                    }
                }
                return buttonCount;
            }
        }

        public int VerticalLineCount
        {
            get
            {
                if (verticalLineCount == 0)
                {
                    verticalLineCount = buttonGrid.Count;
                }
                return verticalLineCount;
            }
        }

        public Buttons()
        {
            buttonGrid = new LinkedList<LinkedList<Button>>();
        }

        public Buttons(LinkedList<LinkedList<Button>> buttonGrid) : this()
        {
            this.buttonGrid = buttonGrid;
            verticalLineCount = this.buttonGrid.Count;
            buttonCount = ButtonCount;
        }

        public Buttons(LinkedList<LinkedList<string>> buttonNames) : this()
        {
            foreach (var buttonLine in buttonNames)
            {
                var thisButtonLine = buttonGrid.AddLast(new LinkedList<Button>()).Value;
                ++verticalLineCount;
                foreach (var buttonName in buttonLine)
                {
                    thisButtonLine.AddLast(new Button(buttonName));
                    ++buttonCount;
                }
            }
        }
    }
}