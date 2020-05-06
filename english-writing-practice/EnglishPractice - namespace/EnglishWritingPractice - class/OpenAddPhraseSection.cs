using System.Linq;
using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void OpenAddPhraseSection<T>() where T : PhraseAndTranslation
        {
            string phrase = null;
            string translation = null;
            string textForPhrase, textForTranslation;
            if (typeof(T) == typeof(RuPhraseAndTranslation))
            {
                textForPhrase = $"{localization["AddPhrase:phrase_in_russian"]} ({localization["AddPhrase:info_1"]}):";
                textForTranslation = $"{localization["AddPhrase:phrase_in_english"]} ({localization["AddPhrase:info_2"]}):";
            }
            else
            {
                textForPhrase = $"{localization["AddPhrase:phrase_in_english"]} ({localization["AddPhrase:info_1"]}):";
                textForTranslation = $"{localization["AddPhrase:phrase_in_russian"]} ({localization["AddPhrase:info_2"]}):";
            }
            string successAdded = $"{localization["AddPhrase:phrase_added"]}. {localization["AddPhrase:press_any_key"]}";
            TextInputtingInterface.VariableInfoPair[] pairs = new[]
            {
                new TextInputtingInterface.VariableInfoPair { Variable = phrase, Info = textForPhrase},
                new TextInputtingInterface.VariableInfoPair { Variable = translation, Info = textForTranslation}
            };
            currentInterface = new TextInputtingInterface(pairs, successAdded, () => $"{programName} - {localization["AddPhrase:section_name"]}");
            (currentInterface as TextInputtingInterface).OnGettingData += (data) =>
            {
                phrase = data.ElementAt(0);
                translation = data.ElementAt(1);
                try
                {
                    if (typeof(T) == typeof(RuPhraseAndTranslation))
                    {
                        RuPhraseAndTranslation.Create(phrase, translation, dataContainer.RuPhrasesDb, dataContainer.EnPhrasesDb);
                    }
                    else
                    {
                        EnPhraseAndTranslation.Create(phrase, translation, dataContainer.EnPhrasesDb, dataContainer.RuPhrasesDb);
                    }
                }
                catch (PhraseExistsException exception)
                {
                    exception.Phrase.AddTranslation(translation);
                }
                SerializeDataContainer();
            };
            (currentInterface as TextInputtingInterface).OnEnding += () => currentSection = Section.AddPhrase_LanguageChoice;
        }
    }
}