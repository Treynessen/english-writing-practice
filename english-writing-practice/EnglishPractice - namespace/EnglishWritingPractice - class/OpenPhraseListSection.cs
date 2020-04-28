using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Treynessen.UI;
using Treynessen.Functions;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void OpenPhraseListSection<T>() where T : PhraseAndTranslation
        {
            // Кнопки интерфейса
            LinkedList<LinkedList<Button>> buttons = new LinkedList<LinkedList<Button>>();
            // Создаем список для кнопок букв
            buttons.AddLast(new LinkedList<Button>());
            string letters = null;
            if (typeof(T) == typeof(RuPhraseAndTranslation))
            {
                letters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            }
            else
            {
                letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
            // Добавляем кнопку "Все фразы" и кнопки букв
            buttons.Last.Value.AddLast(new Button($"[ {localization["PhraseList:show_all_button"]} ]"));
            buttons.AddLast(new LinkedList<Button>());
            int letterGridHorizontalCount = Convert.ToInt32(localization["PhraseList:letter_grid_horizontal_count"]);
            int previousFirstEl = 0;
            for (int i = 0; i < letters.Length; ++i)
            {
                if (previousFirstEl + letterGridHorizontalCount == i)
                {
                    previousFirstEl = i;
                    buttons.AddLast(new LinkedList<Button>());
                }
                Button button = new Button($"[ {letters[i]} ]");
                buttons.Last.Value.AddLast(button);
            }
            // Добавляем события OnPressed к вышедобаленным кнопкам
            for (var verticalLineNode = buttons.First; verticalLineNode != null; verticalLineNode = verticalLineNode.Next)
            {
                for (var buttonNode = verticalLineNode.Value.First; buttonNode != null; buttonNode = buttonNode.Next)
                {
                    if (buttonNode != buttons.First.Value.First)
                    {
                        buttonNode.Value.OnPressed += AddOnPressedEventHandlerToLetterButton<T>(buttonNode.Value, buttons);
                    }
                    else
                    {
                        buttonNode.Value.OnPressed += AddOnPressedEventHandlerToLetterButton<T>(buttonNode.Value, buttons, true);
                    }
                }
            }
            // Создаем кнопку "Назад" и добавляем её в начало списка
            Button backButton = new Button(localization["PhraseList:back_button"]);
            backButton.OnPressed += () => currentSection = Section.PhraseList_LanguageChoice;
            buttons.AddFirst(new LinkedList<Button>()).Value.AddLast(backButton);
            // Создаем интерфейс
            currentInterface = new ButtonInterface(
                buttons: new Buttons(buttons),
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization["PhraseList:SectionName"]}",
                soundEffect: () => soundEffect
            );
            (currentInterface as ButtonInterface).StopAfterClickedEnterKey += () => currentSection == Section.PhraseList_LanguageChoice;
        }

        private Action AddOnPressedEventHandlerToLetterButton<T>
            (Button button, LinkedList<LinkedList<Button>> headerButtons, bool showAllButton = false)
        {
            return () =>
            {
                Console.Clear();
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
                    Regex regex = new Regex(@"\[ (?<letter1>[A-Z]|[А-Я]) \]");
                    phrases = phrases.Where(p => p.Phrase.StartsWith(regex.Match(button.Name).Groups[1].ToString(), StringComparison.OrdinalIgnoreCase));
                }
                // Создаем кнопки для каждой фразы: Фраза Изменить Удалить
                LinkedList<LinkedList<Button>> phraseButtons = new LinkedList<LinkedList<Button>>();
                foreach (var phrase in phrases)
                {
                    var verticalNode = phraseButtons.AddLast(new LinkedList<Button>());
                    Button phraseButton = new Button(phrase.Phrase);
                    // Добавить обработчик события для phraseButton
                    verticalNode.Value.AddLast(phraseButton);
                    Button editButton = new Button(localization["PhraseList:edit_button"]);
                    // Добавить обработчик события для editButton
                    verticalNode.Value.AddLast(editButton);
                    Button deleteButton = new Button(localization["PhraseList:delete_button"]);
                    // Добавить обработчик события для deleteButton
                    verticalNode.Value.AddLast(deleteButton);
                }
                if (currentInterface is ButtonInterface buttonInterface)
                {
                    buttonInterface.Buttons = new Buttons(headerButtons.Union(phraseButtons));
                }
            };
        }
    }
}