using System;
using System.Collections.Generic;
using Treynessen.UI;

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
            backButton.OnPressed += () => this.currentSection = Section.PhraseList_LanguageChoice;
            buttons.AddFirst(new LinkedList<Button>()).Value.AddLast(backButton);
            // Создаем интерфейс
            currentInterface = new ButtonInterface(
                buttons: new Buttons(buttons),
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization["PhraseList:SectionName"]}",
                soundEffect: () => soundEffect
            );
            Section currentSection = this.currentSection;
            (currentInterface as ButtonInterface).StopAfterClickedEnterKey += () => this.currentSection != currentSection;
        }
    }
}