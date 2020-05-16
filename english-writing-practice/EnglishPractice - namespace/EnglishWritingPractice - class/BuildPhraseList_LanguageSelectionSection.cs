using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        // Menu -> PhraseList_LanguageSelection
        private IUserInterface BuildPhraseList_LanguageSelectionSection()
        {
            string sectionName = "phrase_list-language_selection";
            Buttons buttons = BuildSectionButtons(sectionName);
            IUserInterface phraseList_LanguageSelectionInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization[$"{sectionName}:section_name"]}",
                withSoundEffect: () => withSoundEffect,
                getHeaderText: () => localization[$"{sectionName}:header"]
            );
            buttons[1].OnPressed += (o, args) =>
            {
                IUserInterface ruPhraseListInterface = BuildPhraseListSection<RuPhraseAndTranslation>();
                ConnectStoppedEvents(phraseList_LanguageSelectionInterface, ruPhraseListInterface);
                ruPhraseListInterface.Display().Wait();
            };
            buttons[2].OnPressed += (o, args) =>
            {
                IUserInterface enPhraseListInterface = BuildPhraseListSection<EnPhraseAndTranslation>();
                ConnectStoppedEvents(phraseList_LanguageSelectionInterface, enPhraseListInterface);
                enPhraseListInterface.Display().Wait();
            };
            buttons[3].OnPressed += (o, args) => phraseList_LanguageSelectionInterface.Stop();
            return phraseList_LanguageSelectionInterface;
        }
    }
}