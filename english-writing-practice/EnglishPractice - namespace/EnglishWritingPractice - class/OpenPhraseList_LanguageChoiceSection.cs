using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void OpenPhraseList_LanguageChoiceSection()
        {
            Buttons buttons = BuildSectionButtons();
            buttons[1].OnPressed += () => currentSection = Section.RuPhraseList;
            buttons[2].OnPressed += () => currentSection = Section.EnPhraseList;
            buttons[3].OnPressed += () => currentSection = Section.Menu;
            currentInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization["PhraseList_LanguageChoice:SectionName"]}",
                soundEffect: () => soundEffect,
                headerText: localization["PhraseList_LanguageChoice:header"]
            );
            (currentInterface as ButtonInterface).StopAfterClickedEnterKey += () => true;
        }
    }
}