using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        // Menu -> PhraseList_LanguageSelection -> PhraseList
        private IUserInterface BuildPhraseListSection<T>() where T : PhraseAndTranslation
        {
            string sectionName = "phrase_list";
            Buttons headerButtons = BuildPhraseListHeaderButtons<T>(sectionName);
            IUserInterface phraseListInterface = new ButtonInterface(
                buttons: headerButtons,
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization[$"{sectionName}:section_name"]}",
                withSoundEffect: () => withSoundEffect
            );
            // Событие при нажатии на кнопку "Назад"
            headerButtons[1].OnPressed += (o, args) => phraseListInterface.Stop();
            // События для получения фраз
            for (int receivePhraseButtonId = 2; receivePhraseButtonId <= headerButtons.ButtonCount; ++receivePhraseButtonId)
            {
                headerButtons[receivePhraseButtonId].OnPressed += (headerButton, args) =>
                {
                    Buttons receivedPhraseButtons = null;
                    // Получаем кнопки фраз:
                    // При нажатии на "Показать все фразы"
                    if (receivePhraseButtonId == 2) receivedPhraseButtons = BuildReceivedPhraseButtons<T>(headerButton as Button, sectionName, true);
                    // При нажатии на букву
                    else receivedPhraseButtons = BuildReceivedPhraseButtons<T>(headerButton as Button, sectionName);
                    // Добавляем события к полученным кнопкам:
                    for (int receivedPhraseVerticalLineId = 1; receivedPhraseVerticalLineId <= receivedPhraseButtons.VerticalLineCount; ++receivedPhraseVerticalLineId)
                    {
                        // Получаем фразу, относящуюся к текущей строке
                        T phrase = dataContainer.GetPhrase<T>(receivedPhraseButtons[receivedPhraseVerticalLineId, 1].Name);
                        // Кнопка "Получить информацию о фразе":
                        receivedPhraseButtons[receivedPhraseVerticalLineId, 1].OnPressed += (o, args) =>
                        {
                            IUserInterface phraseInfoInterface = BuildPhraseInfoSection(phrase);
                            ConnectStoppedEvents(phraseListInterface, phraseInfoInterface);
                            phraseInfoInterface.Display().Wait();
                            // Если после выхода из интерфейса фраза удалена, тогда удаляем строку с этой кнопкой
                            // и поднимаем таргет наверх
                            if (phrase.Deleted)
                            {
                                ButtonInterface _phraseListInterface = phraseListInterface as ButtonInterface;
                                _phraseListInterface.Buttons.RemoveVerticalLine(_phraseListInterface.Position.Item1);
                                _phraseListInterface.Position = (_phraseListInterface.Position.Item1 - 1, _phraseListInterface.Position.Item2);
                            }
                        };
                        // Кнопка "Изменить фразу"
                        receivedPhraseButtons[receivedPhraseVerticalLineId, 2].OnPressed += (o, args) =>
                        {
                            IUserInterface editingPhraseInterface = BuildEditingPhraseSection(phrase);
                            ConnectStoppedEvents(phraseListInterface, editingPhraseInterface);
                            editingPhraseInterface.Display().Wait();
                            // Обновляем значения кнопок
                            (headerButton as Button).Press();
                            ButtonInterface _phraseListInterface = phraseListInterface as ButtonInterface;
                            if (_phraseListInterface.Position.Item1 > _phraseListInterface.Buttons.VerticalLineCount)
                            {
                                _phraseListInterface.Position = (_phraseListInterface.Buttons.VerticalLineCount, _phraseListInterface.Position.Item2);
                            }
                        };
                        // Кнопка "Удалить фразу"
                        receivedPhraseButtons[receivedPhraseVerticalLineId, 3].OnPressed += (o, args) =>
                        {
                            ButtonInterface _phraseListInterface = phraseListInterface as ButtonInterface;
                            phrase.Delete();
                            SerializeDataContainer();
                            _phraseListInterface.Buttons.RemoveVerticalLine(_phraseListInterface.Position.Item1);
                            _phraseListInterface.Position = (_phraseListInterface.Position.Item1 - 1, _phraseListInterface.Position.Item2);
                        };
                    }
                    // Соединяем headerButtons и receivedPhraseButtons и передаем полученные кнопки объекту интерфейса
                    (phraseListInterface as ButtonInterface).Buttons = Buttons.Union(headerButtons, receivedPhraseButtons);
                };
            }
            return phraseListInterface;
        }
    }
}