namespace Treynessen.UI
{
    public partial class UserInterface
    {
        private void PressedButtonAction()
        {
            if (currentSection == Section.Menu)
            {
                MenuSection_ButtonsHandler();
            }
            else if (currentSection == Section.SoundSettings)
            {
                SoundSettingsSection_ButtonsHandler();
            }
        }
    }
}