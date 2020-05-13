using System;
using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private Buttons BuildPhraseListHeaderButtons<T>(string sectionName) where T : PhraseAndTranslation
        {
            Buttons headerButtons = new Buttons();
            // Создаем и добавляем кнопку Назад
            Button backButton = new Button(localization["common:back_button"]);
            headerButtons.AddButton(1, 1, backButton);
            // Создаем и добавляем кнопку Показать все фразы
            Button showAllPhrases = new Button($"[ {localization[$"{sectionName}:show_all_button"]} ]");
            headerButtons.AddButton(2, 1, showAllPhrases);
            string letters = null;
            if (typeof(T) == typeof(RuPhraseAndTranslation))
            {
                letters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            }
            else
            {
                letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
            // Получаем количество кнопок букв в линии 
            int letterButtonHorizontalCount = Convert.ToInt32(coreConfiguration["letter_button_horizontal_count"]);
            int verticalLineId = 3, horizontalButtonId = 1;
            foreach (var letter in letters)
            {
                if (horizontalButtonId > letterButtonHorizontalCount)
                {
                    ++verticalLineId;
                    horizontalButtonId = 1;
                }
                Button letterButton = new Button($"[ {letter} ]");
                headerButtons.AddButton(verticalLineId, horizontalButtonId, letterButton);
                ++horizontalButtonId;
            }
            return headerButtons;
        }
    }
}