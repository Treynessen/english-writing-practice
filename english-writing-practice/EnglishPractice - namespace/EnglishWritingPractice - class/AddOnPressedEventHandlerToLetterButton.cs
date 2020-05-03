using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
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
                    // Добавляем кнопку для получения информации о фразе
                    Button phraseButton = new Button(phrase.Phrase);
                    phraseButton.OnPressed += () =>
                    {
                        // Сделать отдельную секцию для информации о переводе
                        // Сделать Button Interface с возможностью удаления перевода
                    };
                    verticalNode.Value.AddLast(phraseButton);
                    // Добавляем кнопку редактирования фразы
                    Button editButton = new Button(localization["PhraseList:edit_button"]);
                    editButton.OnPressed += () =>
                    {
                        Console.Clear();
                        Console.CursorVisible = true;
                        Console.WriteLine(localization["PhraseList:input_empty_to_exit"]);
                        Console.WriteLine($"{localization["PhraseList:input_new_phrase"]} ({localization["PhraseList:current_phrase"]} {phrase.Phrase}):");
                        string newPhrase = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newPhrase))
                        {
                            phrase.Edit(newPhrase);
                            phraseButton.Rename(newPhrase);
                        }
                        Console.CursorVisible = false;
                    };
                    verticalNode.Value.AddLast(editButton);
                    // Добавляем кнопку удаления
                    Button deleteButton = new Button(localization["PhraseList:delete_button"]);
                    deleteButton.OnPressed += () =>
                    {
                        phrase.Delete();
                        if (currentInterface is ButtonInterface buttonInterface)
                        {
                            int currentVerticalLineId = buttonInterface.Position.Item1;
                            buttonInterface.Buttons.RemoveVerticalLine(currentVerticalLineId);
                            if (currentVerticalLineId > buttonInterface.Buttons.GetVerticalLineCount())
                            {
                                buttonInterface.Position = (currentVerticalLineId - 1, buttonInterface.Position.Item2);
                            }
                        }
                        SerializeDataContainer();
                    };
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