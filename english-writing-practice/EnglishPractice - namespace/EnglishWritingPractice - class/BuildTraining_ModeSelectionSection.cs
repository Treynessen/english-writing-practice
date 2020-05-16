using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        // Menu -> Training_ModeSelection
        private IUserInterface BuildTraining_ModeSelectionSection()
        {
            string sectionName = "training-mode_selection";
            Buttons buttons = BuildSectionButtons(sectionName);
            ButtonInterface training_ModeSelectionInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization[$"{sectionName}:section_name"]}",
                withSoundEffect: () => withSoundEffect,
                getHeaderText: () => $"{localization[$"{sectionName}:header"]}"
            );
            buttons[1].OnPressed += (o, args) =>
            {
                IUserInterface trainingInterface = BuildTrainingSection(
                    translateFromEnglish: true,
                    translateFromRussian: false
                );
                ConnectStoppedEvents(training_ModeSelectionInterface, trainingInterface);
                trainingInterface.Display().Wait();
            };
            buttons[2].OnPressed += (o, args) =>
            {
                IUserInterface trainingInterface = BuildTrainingSection(
                    translateFromEnglish: false,
                    translateFromRussian: true
                );
                ConnectStoppedEvents(training_ModeSelectionInterface, trainingInterface);
                trainingInterface.Display().Wait();
            };
            buttons[3].OnPressed += (o, args) =>
            {
                IUserInterface trainingInterface = BuildTrainingSection(
                    translateFromEnglish: true,
                    translateFromRussian: true
                );
                ConnectStoppedEvents(training_ModeSelectionInterface, trainingInterface);
                trainingInterface.Display().Wait();
            };
            buttons[4].OnPressed += (o, args) => training_ModeSelectionInterface.Stop();
            return training_ModeSelectionInterface;
        }
    }
}