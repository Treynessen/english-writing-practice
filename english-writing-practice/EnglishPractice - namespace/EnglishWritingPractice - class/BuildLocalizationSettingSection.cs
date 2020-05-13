using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        // Menu -> LocalizationSetting
        private IUserInterface BuildLocalizationSettingSection()
        {
            string sectionName = "localization_setting";
            Buttons buttons = BuildLocalizationSettingButtons();
            Button backButton = new Button(localization["common:back_button"]);
            buttons.AddButton(buttons.ButtonCount + 1, 1, backButton);
            IUserInterface localizationSettingInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization[$"{sectionName}:section_name"]}",
                withSoundEffect: () => withSoundEffect
            );
            backButton.OnPressed += (o, args) => localizationSettingInterface.Stop();
            return localizationSettingInterface;
        }
    }
}