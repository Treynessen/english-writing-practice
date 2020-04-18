using System;

namespace Treynessen.UI
{
    public partial class Buttons
    {
        public (int, int) GetButtonId(int buttonNum)
        {
            int remainder = buttonNum;
            for (int i = 0; i < buttons.Length; ++i)
            {
                if (remainder - buttons[i].Length < 1)
                {
                    return (i + 1, remainder);
                }
                else
                {
                    remainder -= buttons[i].Length;
                }
            }
            throw new IndexOutOfRangeException($"Button №{buttonNum} hasn't found");
        }
    }
}