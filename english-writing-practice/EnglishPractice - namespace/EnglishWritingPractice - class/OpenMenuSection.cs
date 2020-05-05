using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void OpenMenuSection()
        {
            Buttons buttons = BuildSectionButtons();
            buttons[1].OnPressed += (o, args) => { };
            buttons[2].OnPressed += (o, args) => currentSection = Section.AddPhrase_LanguageChoice;
            buttons[3].OnPressed += (o, args) => currentSection = Section.PhraseList_LanguageChoice;
            buttons[4].OnPressed += (o, args) => currentSection = Section.LocalizationSettings;
            buttons[5].OnPressed += (o, args) => currentSection = Section.SoundSettings;
            buttons[6].OnPressed += (o, args) => Stop();
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