using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void OpenPhraseList_LanguageChoiceSection()
        {
            Buttons buttons = BuildSectionButtons();
            buttons[1].OnPressed += (o, args) => currentSection = Section.RuPhraseList;
            buttons[2].OnPressed += (o, args) => currentSection = Section.EnPhraseList;
            buttons[3].OnPressed += (o, args) => currentSection = Section.Menu;
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