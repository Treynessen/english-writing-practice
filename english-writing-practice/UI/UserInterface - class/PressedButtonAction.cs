using System;

namespace Treynessen.UI
{
    public partial class UserInterface
    {
        private void PressedButtonAction()
        {
            if (currentSection == Section.Menu)
            {
                MenuButtonsHandler();
            }
            else if (currentSection == Section.SoundSettings)
            {
                SoundSettingsButtonsHandler();
            }
        }
    }
}