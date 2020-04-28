using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void OpenAddPhrase_LanguageChoiceSection()
        {
            Buttons buttons = BuildSectionButtons();
            buttons[1].OnPressed += () => currentSection = Section.AddRuPhrase;
            buttons[2].OnPressed += () => currentSection = Section.AddEnPhrase;
            buttons[3].OnPressed += () => currentSection = Section.Menu;
            currentInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization["AddPhrase_LanguageChoice:SectionName"]}",
                soundEffect: () => soundEffect,
                headerText: localization["AddPhrase_LanguageChoice:header"]
            );
            (currentInterface as ButtonInterface).StopAfterClickedEnterKey += () => true;
        }
    }
}