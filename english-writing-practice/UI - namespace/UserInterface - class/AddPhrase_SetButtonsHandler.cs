using System;
using Treynessen.EnglishPractice;

namespace Treynessen.UI
{
    public partial class UserInterface
    {
        private void AddPhrase_SetButtonsHandler()
        {
            buttons[1].OnPressed += () =>
            {
                string russianPhrase = null;
                string englishPhrase = null;
                string textForPhrase = $"{localization["AddPhrase:phrase_in_russian"]} ({localization["AddPhrase:info_1"]}):";
                string textForTranslation = $"{localization["AddPhrase:phrase_in_english"]} ({localization["AddPhrase:info_2"]}):";
                do
                {
                    InputPhraseAndTranslation(textForPhrase, textForTranslation, out russianPhrase, out englishPhrase);
                    if (!string.IsNullOrEmpty(russianPhrase))
                    {
                        RuPhraseAndTranslation phrase = new RuPhraseAndTranslation(russianPhrase, englishPhrase, ruPhrasesDb, enPhrasesDb);
                    }
                } while (!string.IsNullOrEmpty(russianPhrase) && !string.IsNullOrEmpty(englishPhrase));
                UpdateInterface();
            };
            buttons[2].OnPressed += () =>
            {
                string englishPhrase = null;
                string russianPhrase = null;
                string textForPhrase = $"{localization["AddPhrase:phrase_in_english"]} ({localization["AddPhrase:info_1"]}):";
                string textForTranslation = $"{localization["AddPhrase:phrase_in_russian"]} ({localization["AddPhrase:info_2"]}):";
                do
                {
                    InputPhraseAndTranslation(textForPhrase, textForTranslation, out englishPhrase, out russianPhrase);
                    if (!string.IsNullOrEmpty(russianPhrase))
                    {
                        EnPhraseAndTranslation phrase = new EnPhraseAndTranslation(englishPhrase, russianPhrase, enPhrasesDb, ruPhrasesDb);
                    }
                } while (!string.IsNullOrEmpty(englishPhrase) && !string.IsNullOrEmpty(russianPhrase));
                UpdateInterface();
            };
            buttons[3].OnPressed += () =>
            {
                parentSection = null;
                currentSection = Section.Menu;
                OpenSection();
            };
        }

        private void InputPhraseAndTranslation(string textForPhrase, string textForTranslation,
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