using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private EventHandler AddOnPressedEventHandlerToLetterButton<T>(Buttons headerButtons, bool showAllButton = false)
        {
            return (object o, EventArgs args) =>
            {
                if (o is Button button)
                {
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
                        phrases = phrases.Where(p => p.Phrase.StartsWith(regex.Match(button.Name).Groups["letter"].ToString(), StringComparison.OrdinalIgnoreCase));
                    }
                    // Создаем кнопки для каждой фразы: Фраза Изменить Удалить
                    Buttons phraseButtons = new Buttons();
                    foreach (var phrase in phrases)
                    {
                        // Добавляем кнопку для получения информации о фразе
                        Button phraseButton = new Button(phrase.Phrase);
                        phraseButton.OnPressed += (_o, _args) =>
                        {
                            Buttons phraseInfoButtons = new Buttons();
                            ButtonInterface infoInterface = new ButtonInterface(
                                buttons: phraseInfoButtons,
                                controlKeyContainer: controlKeyContainer,
                                getTitle: () => $"{programName} - {localization["PhraseList:phrase_info"]}",
                                withSoundEffect: () => soundEffect,
                                headerText: $"{localization["PhraseList:phrase"]}: {phrase.Phrase}\n{localization["PhraseList:translations"]}:"
                            );
                            // Создаем кнопки удаления перевода
                            int currentVerticalLine = 1;
                            foreach (var translation in phrase.Translations)
                            {
                                Button translationButton = new Button(translation.Phrase, false);
                                Button deleteTranslationButton = new Button(localization["PhraseList:delete_button"]);
                                deleteTranslationButton.OnPressed += (_o, _args) =>
                                {
                                    phrase.DeleteTranslation(translation);
                                    phraseInfoButtons.RemoveVerticalLine(infoInterface.Position.Item1);
                                    // Таргет на кнопку назад не перемещаем, т.к. при удалении всех переводов удаляется и фраза,
                                    // поэтому нужно вернуться на предыдущий интерфейс и очистить там строку с фразой
                                    if (infoInterface.Position.Item1 > 1)
                                    {
                                        infoInterface.Position = (infoInterface.Position.Item1 - 1, infoInterface.Position.Item2);
                                    }
                                    if (phrase.Deleted && currentInterface is ButtonInterface _currentInterface)
                                    {
                                        _currentInterface.Buttons.RemoveVerticalLine(_currentInterface.Position.Item1);
                                        _currentInterface.Position = (_currentInterface.Position.Item1 - 1, _currentInterface.Position.Item2);
                                    }
                                    SerializeDataContainer();
                                };
                                phraseInfoButtons.AddButton(currentVerticalLine, 1, translationButton);
                                phraseInfoButtons.AddButton(currentVerticalLine++, 2, deleteTranslationButton);
                            }
                            // Добавляем кнопку назад
                            Button backButton = new Button(localization["PhraseList:back_button"]);
                            phraseInfoButtons.AddButton(currentVerticalLine, 1, backButton);
                            infoInterface.OnPressingEnter += (o, args) =>
                            {
                                if (o is ButtonInterface _infoInterface && ReferenceEquals(backButton, _infoInterface.Target))
                                {
                                    _infoInterface.StopSinceNextFrame();
                                }
                            };
                            infoInterface.OnPressedEnter += (o, args) =>
                            {
                                if (o is ButtonInterface _infoInterface && _infoInterface.Buttons.ButtonCount <= 1)
                                {
                                    _infoInterface.StopSinceNextFrame();
                                }
                            };
                            infoInterface.Display().Wait();
                        };
                        phraseButtons.AddButton(phraseButtons.VerticalLineCount + 1, 1, phraseButton);
                        // Добавляем кнопку редактирования фразы
                        Button editButton = new Button(localization["PhraseList:edit_button"]);
                        editButton.OnPressed += (_o, _args) =>
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
                        phraseButtons.AddButton(phraseButtons.VerticalLineCount, 2, editButton);
                        // Добавляем кнопку удаления
                        Button deleteButton = new Button(localization["PhraseList:delete_button"]);
                        deleteButton.OnPressed += (_o, _args) =>
                        {
                            phrase.Delete();
                            if (currentInterface is ButtonInterface buttonInterface)
                            {
                                int currentVerticalLineId = buttonInterface.Position.Item1;
                                buttonInterface.Buttons.RemoveVerticalLine(currentVerticalLineId);
                                if (currentVerticalLineId > buttonInterface.Buttons.VerticalLineCount)
                                {
                                    buttonInterface.Position = (currentVerticalLineId - 1, buttonInterface.Position.Item2);
                                }
                            }
                            SerializeDataContainer();
                        };
                        phraseButtons.AddButton(phraseButtons.VerticalLineCount, 3, deleteButton);
                    }
                    if (currentInterface is ButtonInterface buttonInterface)
                    {
                        buttonInterface.Buttons = Buttons.Union(headerButtons, phraseButtons);
                    }
                }
            };
        }
    }
}