namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void Menu_SetButtonHandlers()
        {
            buttons[1].OnPressed += () => { };
            buttons[2].OnPressed += () =>
            {
                parentSection = Section.Menu;
                currentSection = Section.AddingPhrase;
            };
            buttons[3].OnPressed += () => { };
            buttons[4].OnPressed += () =>
            {
                parentSection = Section.Menu;
                currentSection = Section.LocalizationSettings;
            };
            buttons[5].OnPressed += () =>
            {
                parentSection = Section.Menu;
                currentSection = Section.SoundSettings;
            };
            buttons[6].OnPressed += () =>
            {
                Stop();
            };
        }
    }
}