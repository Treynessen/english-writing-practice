namespace Treynessen.UI
{
    public partial class UserInterface
    {
        private void Menu_SetButtonsHandler()
        {
            buttons[1].OnPressed += () => { };
            buttons[2].OnPressed += () => { };
            buttons[3].OnPressed += () => { };
            buttons[4].OnPressed += () => 
            {
                parentSection = Section.Menu;
                currentSection = Section.LocalizationSettings;
                OpenSection();
            };
            buttons[5].OnPressed += () =>
            {
                parentSection = Section.Menu;
                currentSection = Section.SoundSettings;
                OpenSection();
            };
            buttons[6].OnPressed += () =>
            {
                Stop();
            };
        }
    }
}