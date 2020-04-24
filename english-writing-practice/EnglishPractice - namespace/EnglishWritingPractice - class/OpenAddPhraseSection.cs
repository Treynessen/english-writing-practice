using System.Linq;
using Treynessen.UI;
using Treynessen.Functions;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void OpenAddPhraseSection()
        {
            BuildSectionButtons();
            buttons[1].OnPressed += AddingPhrase<RuPhraseAndTranslation>;
            buttons[2].OnPressed += AddingPhrase<EnPhraseAndTranslation>;
            buttons[3].OnPressed += () =>
            {
                parentSection = null;
                currentSection = Section.Menu;
                OpenSection();
            };
            currentInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getName: () => $"{programName} - {localization["AddPhrase:SectionName"]}",
                soundEffect: () => soundEffect,
                headerText: localization["AddPhrase:header"]
            );
            (currentInterface as ButtonInterface).StopAfterClickedEnterKey += () =>
            {
                if (currentSection != Section.AddPhrase) return true;
                else return false;
            };
        }

        private void AddingPhrase<T>() where T : PhraseAndTranslation
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
            currentInterface = new TextInputtingInterface(pairs, successAdded);
            (currentInterface as TextInputtingInterface).OnGettingData += (data) =>
            {
                phrase = data.ElementAt(0);
                translation = data.ElementAt(1);
                if (typeof(T) == typeof(RuPhraseAndTranslation))
                {
                    RuPhraseAndTranslation.Create(phrase, translation, dataContainer.RuPhrasesDb, dataContainer.EnPhrasesDb);
                }
                else
                {
                    EnPhraseAndTranslation.Create(phrase, translation, dataContainer.EnPhrasesDb, dataContainer.RuPhrasesDb);
                }

                StaticFunctions.Serialize(
                    path: "dictionary.data",
                    obj: dataContainer
                );
            };
            currentInterface.Display();
        }
    }
}