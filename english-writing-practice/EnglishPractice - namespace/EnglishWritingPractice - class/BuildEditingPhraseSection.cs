using System.Linq;
using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        // Menu -> PhraseList_LanguageSelection -> PhraseList -> PhraseList_EditingPhrase
        private IUserInterface BuildEditingPhraseSection(PhraseAndTranslation phrase)
        {
            string sectionName = "phrase_list-editing_phrase";
            TextInputtingInterface.VariableInfoPair[] variableInfoPairs =
            {
                new TextInputtingInterface.VariableInfoPair { 
                    Info = $"{localization[$"{sectionName}:input_empty_to_exit"]}\n" +
                    $"{localization[$"{sectionName}:input_new_phrase"]} ({localization[$"{sectionName}:current_phrase"]} {phrase.Phrase})" 
                }
            };
            TextInputtingInterface phraseEditingInterface = new TextInputtingInterface(
                variableInfoPairs: variableInfoPairs,
                successfulInputtingMsg: localization[$"{sectionName}:phrase_was_edited"],
                getTitle: () => $"{programName} - {localization[$"{sectionName}:section_name"]}"
            );
            phraseEditingInterface.OnGettingData += (newPhrases) =>
            {
                phrase.Edit(newPhrases.ElementAt(0));
                SerializeDataContainer();
                phraseEditingInterface.Stop();
            };
            return phraseEditingInterface;
        }
    }
}