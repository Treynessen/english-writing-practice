using Treynessen.UI;
using Treynessen.Functions;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void OpenSoundSettingsSection()
        {
            Buttons buttons = BuildSectionButtons();
            buttons[1].OnPressed += () =>
            {
                soundEffect = true;
                StaticFunctions.EditSettingInConfig(
                    path: "config.ini",
                    settingKey: "sound_effect",
                    newValue: soundEffect.ToString().ToLower()
                );
                StaticFunctions.OpenConfig("config.ini", out coreConfiguration);
            };
            buttons[2].OnPressed += () =>
            {
                soundEffect = false;
                StaticFunctions.EditSettingInConfig(
                    path: "config.ini",
                    settingKey: "sound_effect",
                    newValue: soundEffect.ToString().ToLower()
                );
                StaticFunctions.OpenConfig("config.ini", out coreConfiguration);
            };
            buttons[3].OnPressed += () => currentSection = Section.Menu;
            currentInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization["SoundSettings:SectionName"]}",
                soundEffect: () => soundEffect
            );
            (currentInterface as ButtonInterface).StopAfterClickedEnterKey += () => currentSection != Section.SoundSettings;
        }
    }
}