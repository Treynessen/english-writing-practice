using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private Buttons BuildReceivedPhraseButtons<T>(Button pressedButton, string sectionName, bool showAllButton = false)
            where T : PhraseAndTranslation
        {
            Buttons phraseButtons = new Buttons();
            // Получаем список фраз, соответствующие нажатой кнопке
            IEnumerable<PhraseAndTranslation> phrases = null;
            if (typeof(T) == typeof(RuPhraseAndTranslation))
            {
                phrases = dataContainer.RuPhrasesDb;
            }
            else
            {
                phrases = dataContainer.EnPhrasesDb;
            }
            if (!showAllButton)
            {
                Regex regex = new Regex(@"\[ (?<letter>[A-Z]|[А-Я]) \]");
                phrases = phrases.Where(p => p.Phrase.StartsWith(regex.Match(pressedButton.Name).Groups["letter"].ToString(), StringComparison.OrdinalIgnoreCase));
            }
            // Создаем для каждой фразы кнопки "Фраза", "Изменить", "Удалить"
            foreach (var phrase in phrases)
            {
                // Кнопка для получения информации о фразе
                Button phraseButton = new Button(phrase.Phrase);
                phraseButtons.AddButton(phraseButtons.VerticalLineCount + 1, 1, phraseButton);
                // Кнопка редактирования фразы
                Button editButton = new Button(localization[$"{sectionName}:edit_button"]);
                phraseButtons.AddButton(phraseButtons.VerticalLineCount, 2, editButton);
                // Кнопка удаления фразы
                Button deleteButton = new Button(localization["common:delete_button"]);
                phraseButtons.AddButton(phraseButtons.VerticalLineCount, 3, deleteButton);
            }
            return phraseButtons;
        }
    }
}