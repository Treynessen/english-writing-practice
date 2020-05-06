using System;
using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void OpenPhraseListSection<T>() where T : PhraseAndTranslation
        {
            Buttons buttons = new Buttons();
            // Создаем и добавляем кнопку Назад
            Button backButton = new Button(localization["PhraseList:back_button"]);
            backButton.OnPressed += (o, args) => this.currentSection = Section.PhraseList_LanguageChoice;
            buttons.AddButton(1, 1, backButton);
            // Создаем и добавляем кнопку Показать все фразы
            Button showAllPhrases = new Button($"[ {localization["PhraseList:show_all_button"]} ]");
            showAllPhrases.OnPressed += AddOnPressedEventHandlerToLetterButton<T>(buttons, true); // 2 - кнопка Назад и кнопка Показать все фразы
            buttons.AddButton(2, 1, showAllPhrases);
            // Получаем количество кнопок букв в линии 
            int letterButtonHorizontalCount = Convert.ToInt32(coreConfiguration["letter_button_horizontal_count"]);
            // Создаем и добавляем кнопки букв
            string letters = null;
            if (typeof(T) == typeof(RuPhraseAndTranslation))
            {
                letters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            }
            else
            {
                letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
            int verticalLineId = 3, horizontalButtonId = 1;
            foreach (var letter in letters)
            {
                if (horizontalButtonId > letterButtonHorizontalCount)
                {
                    ++verticalLineId;
                    horizontalButtonId = 1;
                }
                Button letterButton = new Button($"[ {letter} ]");
                letterButton.OnPressed += AddOnPressedEventHandlerToLetterButton<T>(buttons); // 2 - кнопка Назад и кнопка Показать все фразы
                buttons.AddButton(verticalLineId, horizontalButtonId, letterButton);
                ++horizontalButtonId;
            }
            // Создаем интерфейс
            currentInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization["PhraseList:section_name"]}",
                withSoundEffect: () => soundEffect
            );
            Section currentSection = this.currentSection;
            (currentInterface as ButtonInterface).OnPressedEnter += (o, args) =>
            {
                if (this.currentSection != currentSection)
                {
                    (o as ButtonInterface)?.StopSinceNextFrame();
                }
            };
        }
    }
}