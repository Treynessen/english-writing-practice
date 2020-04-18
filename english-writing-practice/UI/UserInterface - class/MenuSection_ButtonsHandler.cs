using System;

namespace Treynessen.UI
{
    public partial class UserInterface
    {
        private void MenuSection_ButtonsHandler()
        {
            switch (buttons.GetButtonNum(verticalOperationNum, horizontalOperationNum))
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:
                    parentSection = Section.Menu;
                    currentSection = Section.SoundSettings;
                    OpenSection();
                    break;
                case 6:
                    Stop();
                    break;
                default:
                    throw new InvalidOperationException($"Operation {(verticalOperationNum, horizontalOperationNum)} doesn't exist");
            }
        }
    }
}