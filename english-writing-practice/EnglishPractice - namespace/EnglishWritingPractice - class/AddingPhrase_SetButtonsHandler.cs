using System;
using Treynessen.Functions;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void AddingPhrase_SetButtonsHandler()
        {
            buttons[1].OnPressed += AddingPhrase<RuPhraseAndTranslation>;
            buttons[2].OnPressed += AddingPhrase<EnPhraseAndTranslation>;
            buttons[3].OnPressed += () =>
            {
                parentSection = null;
                currentSection = Section.Menu;
                OpenSection();
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
            do
            {
                InputtingPhraseAndTranslation(textForPhrase, textForTranslation, out phrase, out translation);
                if (!string.IsNullOrEmpty(phrase))
                {
                    if (typeof(T) == typeof(RuPhraseAndTranslation))
                    {
                        RuPhraseAndTranslation.Create(phrase, translation, ruPhrasesDb, enPhrasesDb);
                    }
                    else
                    {
                        EnPhraseAndTranslation.Create(phrase, translation, enPhrasesDb, ruPhrasesDb);
                    }
                    StaticFunctions.Serialize(
                        path: "dictionary.data",
                        obj: new PhraseAndTranslationContainer { ruPhrasesDb = ruPhrasesDb, enPhrasesDb = enPhrasesDb }
                    );
                    Console.Write(successAdded);
                    Console.ReadKey();
                }
            } while (!string.IsNullOrEmpty(phrase) && !string.IsNullOrEmpty(translation));
            //UpdateInterface();
        }

        private void InputtingPhraseAndTranslation(string textForPhrase, string textForTranslation,
            out string phrase, out string translation)
        {
            phrase = translation = null;
            do
            {
                Console.Clear();
                Console.WriteLine(textForPhrase);
                phrase = Console.ReadLine();
                if (string.IsNullOrEmpty(phrase))
                {
                    return;
                }
                Console.WriteLine(textForTranslation);
                translation = Console.ReadLine();
                if (string.IsNullOrEmpty(translation))
                {
                    continue;
                }
            } while (!string.IsNullOrEmpty(phrase) && string.IsNullOrEmpty(translation));
        }
    }
}