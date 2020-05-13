using Treynessen.UI;
using Treynessen.Functions;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        // Menu -> SoundSetting
        private IUserInterface BuildSoundSettingSection()
        {
            string sectionName = "sound_setting_section";
            Buttons buttons = BuildSectionButtons(sectionName);
            IUserInterface soundSettingInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization[$"{sectionName}:section_name"]}",
                withSoundEffect: () => withSoundEffect
            );
            buttons[1].OnPressed += (o, args) =>
            {
                withSoundEffect = true;
                StaticFunctions.EditSettingInConfig(
                    path: "config.ini",
                    settingKey: "sound_effect",
                    newValue: withSoundEffect.ToString().ToLower()
                );
                StaticFunctions.OpenConfig("config.ini", out coreConfiguration);
            };
            buttons[2].OnPressed += (o, args) =>
            {
                withSoundEffect = false;
                StaticFunctions.EditSettingInConfig(
                    path: "config.ini",
                    settingKey: "sound_effect",
                    newValue: withSoundEffect.ToString().ToLower()
                );
                StaticFunctions.OpenConfig("config.ini", out coreConfiguration);
            };
            buttons[3].OnPressed += (o, args) => soundSettingInterface.Stop();
            return soundSettingInterface;
        }
    }
}