using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        // Menu -> AddPhrase_LanguageSelection
        private IUserInterface BuildAddPhrase_LanguageSelectionSection()
        {
            string sectionName = "add_phrase-language_selection";
            Buttons buttons = BuildSectionButtons(sectionName);
            IUserInterface addPhrase_LanguageSelectionInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization[$"{sectionName}:section_name"]}",
                withSoundEffect: () => withSoundEffect,
                getHeaderText: () => localization[$"{sectionName}:header"]
            );
            buttons[1].OnPressed += (o, args) =>
            {
                IUserInterface addRuPhraseInterface = BuildAddPhraseSection<RuPhraseAndTranslation>();
                ConnectStoppedEvents(addPhrase_LanguageSelectionInterface, addRuPhraseInterface);
                addRuPhraseInterface.Display().Wait();
            };
            buttons[2].OnPressed += (o, args) =>
            {
                IUserInterface addEnPhraseInterface = BuildAddPhraseSection<EnPhraseAndTranslation>();
                ConnectStoppedEvents(addPhrase_LanguageSelectionInterface, addEnPhraseInterface);
                addEnPhraseInterface.Display().Wait();
            };
            buttons[3].OnPressed += (o, args) => addPhrase_LanguageSelectionInterface.Stop();
            return addPhrase_LanguageSelectionInterface;
        }
    }
}