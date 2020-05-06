using Treynessen.UI;
using Treynessen.Functions;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void OpenSoundSettingsSection()
        {
            Buttons buttons = BuildSectionButtons();
            buttons[1].OnPressed += (o, args) =>
            {
                soundEffect = true;
                StaticFunctions.EditSettingInConfig(
                    path: "config.ini",
                    settingKey: "sound_effect",
                    newValue: soundEffect.ToString().ToLower()
                );
                StaticFunctions.OpenConfig("config.ini", out coreConfiguration);
            };
            buttons[2].OnPressed += (o, args) =>
            {
                soundEffect = false;
                StaticFunctions.EditSettingInConfig(
                    path: "config.ini",
                    settingKey: "sound_effect",
                    newValue: soundEffect.ToString().ToLower()
                );
                StaticFunctions.OpenConfig("config.ini", out coreConfiguration);
            };
            buttons[3].OnPressed += (o, args) => currentSection = Section.Menu;
            currentInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization["SoundSettings:section_name"]}",
                withSoundEffect: () => soundEffect
            );
            (currentInterface as ButtonInterface).OnPressedEnter += (o, args) =>
            {
                if (currentSection != Section.SoundSettings)
                {
                    (o as ButtonInterface)?.StopSinceNextFrame();
                }
            };
        }
    }
}