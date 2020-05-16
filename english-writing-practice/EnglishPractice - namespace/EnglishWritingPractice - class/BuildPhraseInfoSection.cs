using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        // Menu -> PhraseList_LanguageSelection -> PhraseList -> PhraseList-PhraseInfo
        private IUserInterface BuildPhraseInfoSection(PhraseAndTranslation phrase)
        {
            string sectionName = "phrase_list-phrase_info";
            Buttons buttons = new Buttons();
            ButtonInterface phraseInfoInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization[$"{sectionName}:section_name"]}",
                withSoundEffect: () => withSoundEffect,
                getHeaderText: () => $"{localization[$"{sectionName}:phrase"]}: {phrase.Phrase}\n{localization[$"{sectionName}:translations"]}:"
            );
            // Добавляем кнопки для удаления перевода
            int verticalLineId = 1;
            foreach (var translation in phrase.Translations)
            {
                Button translationButton = new Button(translation.Phrase, false);
                buttons.AddButton(verticalLineId, 1, translationButton);
                Button deleteTranslationButton = new Button($"{localization["common:delete_button"]}");
                deleteTranslationButton.OnPressed += (o, args) =>
                {
                    phrase.DeleteTranslation(translation);
                    SerializeDataContainer();
                    buttons.RemoveVerticalLine(phraseInfoInterface.Position.Item1);
                    if (phraseInfoInterface.Position.Item1 != 1 && phraseInfoInterface.Position.Item1 == buttons.VerticalLineCount)
                    {
                        phraseInfoInterface.Position = (phraseInfoInterface.Position.Item1 - 1, phraseInfoInterface.Position.Item2);
                    }
                    if (phrase.Deleted)
                    {
                        phraseInfoInterface.Stop();
                    }
                };
                buttons.AddButton(verticalLineId++, 2, deleteTranslationButton);
            }
            // Добавляем кнопку "Назад"
            Button backButton = new Button($"{localization["common:back_button"]}");
            backButton.OnPressed += (o, args) => phraseInfoInterface.Stop();
            buttons.AddButton(buttons.VerticalLineCount + 1, 1, backButton);
            return phraseInfoInterface;
        }
    }
}