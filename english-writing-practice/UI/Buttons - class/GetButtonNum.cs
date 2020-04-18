using System;

namespace Treynessen.UI
{
    public partial class Buttons
    {
        public int GetButtonNum((int, int) buttonId)
        {
            (int rowId, int columnId) = buttonId;
            if (rowId > buttons.Length || columnId > buttons[rowId - 1].Length)
            {
                throw new IndexOutOfRangeException($"Button[{rowId};{columnId}] hasn't found");
            }
            int buttonNum = 0;
            for (int i = 0; i < rowId - 1; ++i)
            {
                buttonNum += buttons[i].Length;
            }
            buttonNum += columnId;
            return buttonNum;
        }

        public int GetButtonNum(int rowId, int columnId) => GetButtonNum((rowId, columnId));
    }
}