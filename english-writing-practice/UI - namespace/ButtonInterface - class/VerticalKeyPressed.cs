using System;

namespace Treynessen.UI
{
    public partial class ButtonInterface
    {
        private bool VerticalKeyPressed(ConsoleKeyInfo pressedKeyInfo)
        {
            if (upKey.HasValue && upKey.Value == pressedKeyInfo.Key)
            {
                return true;
            }
            else if (downKey.HasValue && downKey.Value == pressedKeyInfo.Key)
            {
                return true;
            }
            return false;
        }
    }
}