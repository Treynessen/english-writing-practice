using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        // Menu
        private IUserInterface BuildMenuSection()
        {
            string sectionName = "menu";
            Buttons buttons = BuildSectionButtons(sectionName);
            ButtonInterface menuInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization[$"{sectionName}:section_name"]}",
                withSoundEffect: () => withSoundEffect
            );
            buttons[1].OnPressed += (o, args) =>
            {
                IUserInterface training_ModeSelectionInterface = BuildTraining_ModeSelectionSection();
                ConnectStoppedEvents(menuInterface, training_ModeSelectionInterface);
                training_ModeSelectionInterface.Display().Wait();
            };
            buttons[2].OnPressed += (o, args) =>
            {
                IUserInterface addPhrase_LanguageSelectionInterface = BuildAddPhrase_LanguageSelectionSection();
                ConnectStoppedEvents(menuInterface, addPhrase_LanguageSelectionInterface);
                addPhrase_LanguageSelectionInterface.Display().Wait();
            };
            buttons[3].OnPressed += (o, args) =>
            {
                IUserInterface phraseList_LanguageSelectionInterface = BuildPhraseList_LanguageSelectionSection();
                ConnectStoppedEvents(menuInterface, phraseList_LanguageSelectionInterface);
                phraseList_LanguageSelectionInterface.Display().Wait();
            };
            buttons[4].OnPressed += (o, args) =>
            {
                ButtonInterface localizationSettingInterface = BuildLocalizationSettingSection() as ButtonInterface;
                // Обновляем названия кнопок у интерфейса menuInterface в зависимости от выбранной локализации
                for (int buttonId = 1; buttonId < localizationSettingInterface.Buttons.ButtonCount; ++buttonId)
                {
                    localizationSettingInterface.Buttons[buttonId].OnPressed += (o, args) => menuInterface.Buttons = BuildSectionButtons(sectionName);
                }
                ConnectStoppedEvents(menuInterface, localizationSettingInterface);
                localizationSettingInterface.Display().Wait();
            };
            buttons[5].OnPressed += (o, args) =>
            {
                IUserInterface soundSettingInterface = BuildSoundSettingSection();
                ConnectStoppedEvents(menuInterface, soundSettingInterface);
                soundSettingInterface.Display().Wait();
            };
            buttons[6].OnPressed += (o, args) => menuInterface.Stop();
            return menuInterface;
        }
    }
}