using System;
using System.Linq;
using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        // Menu -> Training_ModeSelection -> Training
        private IUserInterface BuildTrainingSection(bool translateFromRussian, bool translateFromEnglish)
        {
            string sectionName = "training";
            Training training = new Training(dataContainer);
            TextInputtingInterface.VariableInfoPair[] variableInfoPairs =
            {
                new TextInputtingInterface.VariableInfoPair()
            };
            TextInputtingInterface trainingInterface = new TextInputtingInterface(
                variableInfoPairs: variableInfoPairs,
                successfulInputtingMsg: $"{localization["common:press_any_key_to_continue"]}",
                getTitle: () => $"{programName} - {localization[$"{sectionName}:section_name"]}"
            );
            trainingInterface.OnBeforeTyping += (o, args) =>
            {
                if (training.EmptyQueue)
                {
                    if (translateFromRussian) training.AddRuPhrasesToQueue(dataContainer.RuPhrasesDb.Count);
                    if (translateFromEnglish) training.AddEnPhrasesToQueue(dataContainer.EnPhrasesDb.Count);
                }
                if (!training.EmptyQueue)
                {
                    variableInfoPairs[0].Info = $"{localization[$"{sectionName}:phrase"]}: {training.GetPhrase().Phrase}\n" +
                        $"{localization[$"{sectionName}:input_translation"]} ({localization[$"{sectionName}:input_empty_to_exit"]}):";
                    if (!training.EmptyQueue && translateFromRussian && translateFromEnglish) training.MixQueue();
                }
                else
                {
                    Console.Write($"{localization[$"{sectionName}:db_is_empty"]}\n{localization["common:press_any_key_to_continue"]}");
                    Console.ReadKey();
                    trainingInterface.Stop();
                }
            };
            trainingInterface.OnGettingData += (translations) =>
            {
                string inputtedTranslation = translations.ElementAt(0);
                bool correctTranslation = training.CorrectTranslation(inputtedTranslation);
                // При получении неверного значения спрашиваем у пользователя
                // является ли это одним из вариантов перевода
                // Для этого создаем ButtonInterface. В качестве header передаем 
                // весь текст с консоли
                if (!correctTranslation)
                {
                    string outputtedText = $"{variableInfoPairs[0].Info}\n{inputtedTranslation}\n" +
                        $"{localization[$"{sectionName}:correct_translations"]}: ";
                    for (var translationNode = training.GetPhrase().Translations.First;
                    translationNode != null; translationNode = translationNode.Next)
                    {
                        outputtedText += $"\"{translationNode.Value.Phrase}\"{(translationNode.Next != null ? "; " : string.Empty)}";
                    }
                    Buttons buttons = new Buttons();
                    buttons.AddButton(1, new Button(localization[$"{sectionName}:yes"]));
                    buttons.AddButton(2, new Button(localization[$"{sectionName}:no"]));
                    IUserInterface choiceInterface = new ButtonInterface(
                        buttons: buttons,
                        controlKeyContainer: controlKeyContainer,
                        getTitle: () => $"{programName} - {localization[$"{sectionName}:section_name"]}",
                        withSoundEffect: () => withSoundEffect,
                        getHeaderText: () => $"{outputtedText}\n{localization[$"{sectionName}:it_is_variant_of_translation"]}"
                    );
                    // Функция восстановления текста в консоли до входа в choiceInterface
                    Action stateRecovery = () =>
                    {
                        Console.Clear();
                        Console.WriteLine(outputtedText);
                        Console.CursorVisible = true;
                    };
                    // Кнопка "Да"
                    buttons[1].OnPressed += (o, args) =>
                    {
                        training.GetPhrase().AddTranslation(inputtedTranslation);
                        correctTranslation = true;
                        choiceInterface.Stop();
                        stateRecovery();
                    };
                    // Кнопка "Нет"
                    buttons[2].OnPressed += (o, args) =>
                    {
                        training.HandlerForIncorrectInput();
                        choiceInterface.Stop();
                        stateRecovery();
                        Console.WriteLine($"{localization[$"{sectionName}:wrong"]}");
                    };
                    ConnectStoppedEvents(trainingInterface, choiceInterface);
                    choiceInterface.Display().Wait();
                }
                if (correctTranslation)
                {
                    Console.WriteLine($"{localization[$"{sectionName}:right"]}");
                    training.HandlerForCorrectInput(phrase => { if (phrase.CorrectAnswersSuccessively >= 30) phrase.Delete(); });
                }
            };
            return trainingInterface;
        }
    }
}