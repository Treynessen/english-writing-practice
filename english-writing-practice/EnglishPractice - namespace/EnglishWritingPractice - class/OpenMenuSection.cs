using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void OpenMenuSection()
        {
            BuildSectionButtons();
            buttons[1].OnPressed += () => { };
            buttons[2].OnPressed += () =>
            {
                parentSection = Section.Menu;
                currentSection = Section.AddPhrase;
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
            currentInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getName: () => $"{programName} - {localization["Menu:SectionName"]}",
                soundEffect: () => soundEffect
            );
            (currentInterface as ButtonInterface).StopAfterClickedEnterKey += () => true;
        }
    }
}