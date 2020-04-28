using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void OpenMenuSection()
        {
            Buttons buttons = BuildSectionButtons();
            buttons[1].OnPressed += () => { };
            buttons[2].OnPressed += () => currentSection = Section.AddPhrase_LanguageChoice;
            buttons[3].OnPressed += () => currentSection = Section.PhraseList_LanguageChoice;
            buttons[4].OnPressed += () => currentSection = Section.LocalizationSettings;
            buttons[5].OnPressed += () => currentSection = Section.SoundSettings;
            buttons[6].OnPressed += () => Stop();
            currentInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization["Menu:SectionName"]}",
                soundEffect: () => soundEffect
            );
            (currentInterface as ButtonInterface).StopAfterClickedEnterKey += () => true;
        }
    }
}