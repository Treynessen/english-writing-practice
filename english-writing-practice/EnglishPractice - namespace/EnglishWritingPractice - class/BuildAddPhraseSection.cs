using System.Linq;
using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        // Menu -> AddPhrase_LanguageSelection -> AddPhrase
        private IUserInterface BuildAddPhraseSection<T>() where T : PhraseAndTranslation
        {
            string sectionName = "add_phrase";
            string textForPhrase, textForTranslation;
            if (typeof(T) == typeof(RuPhraseAndTranslation))
            {
                textForPhrase = $"{localization[$"{sectionName}:phrase_in_russian"]} ({localization[$"{sectionName}:info_1"]}):";
                textForTranslation = $"{localization[$"{sectionName}:phrase_in_english"]} ({localization[$"{sectionName}:info_2"]}):";
            }
            else
            {
                textForPhrase = $"{localization[$"{sectionName}:phrase_in_english"]} ({localization[$"{sectionName}:info_1"]}):";
                textForTranslation = $"{localization[$"{sectionName}:phrase_in_russian"]} ({localization[$"{sectionName}:info_2"]}):";
            }
            string successAdded = $"{localization[$"{sectionName}:phrase_added"]}. {localization[$"common:press_any_key_to_continue"]}";
            TextInputtingInterface.VariableInfoPair[] pairs = new[]
            {
                new TextInputtingInterface.VariableInfoPair { Info = textForPhrase},
                new TextInputtingInterface.VariableInfoPair { Info = textForTranslation}
            };
            TextInputtingInterface addPhraseInterface = new TextInputtingInterface(pairs, successAdded, () => $"{programName} - {localization[$"{sectionName}:section_name"]}");
            addPhraseInterface.OnGettingData += (data) =>
            {
                string phrase = data.ElementAt(0);
                string translation = data.ElementAt(1);
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
            return addPhraseInterface;
        }
    }
}