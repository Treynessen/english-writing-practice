using System;

namespace Treynessen.UI
{
    public partial class ButtonInterface
    {
        private bool HorizontalKeyPressed(ConsoleKeyInfo pressedKeyInfo)
        {
            if (leftKey.HasValue && leftKey.Value == pressedKeyInfo.Key)
            {
                return true;
            }
            else if (rightKey.HasValue && rightKey.Value == pressedKeyInfo.Key)
            {
                return true;
            }
            return false;
        }
    }
}