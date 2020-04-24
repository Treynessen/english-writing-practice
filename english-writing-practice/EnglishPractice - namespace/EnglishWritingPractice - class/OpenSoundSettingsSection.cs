using Treynessen.UI;
using Treynessen.Functions;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void OpenSoundSettingsSection()
        {
            BuildSectionButtons();
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
            buttons[3].OnPressed += () =>
            {
                parentSection = null;
                currentSection = Section.Menu;
                OpenSection();
            };
            currentInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getName: () => $"{programName} - {localization["SoundSettings:SectionName"]}",
                soundEffect: () => soundEffect
            );
            (currentInterface as ButtonInterface).StopAfterClickedEnterKey += () =>
            {
                if (currentSection == Section.Menu) return true;
                else return false;
            };
        }
    }
}