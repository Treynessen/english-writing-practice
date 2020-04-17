using System;

namespace Treynessen.UI
{
    public partial class UserInterface
    {
        private void MenuButtonsHandler()
        {
            switch (operationNum)
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

                    break;
                default:
                    throw new InvalidOperationException($"Operation {operationNum} doesn't exist");
            }
        }
    }
}