using Treynessen.Functions;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void SoundSettings_SetButtonsHandler()
        {
            buttons[1].OnPressed += () =>
            {
                soundEffect = true;
                StaticFunctions.EditSettingInConfig(
                    path: configFolderPath + "/core_config.ini",
                    settingKey: "sound_effect",
                    newValue: soundEffect.ToString().ToLower()
                );
                StaticFunctions.OpenConfig(configFolderPath + "/core_config.ini", out coreConfiguration);
            };
            buttons[2].OnPressed += () =>
            {
                soundEffect = false;
                StaticFunctions.EditSettingInConfig(
                    path: configFolderPath + "/core_config.ini",
                    settingKey: "sound_effect",
                    newValue: soundEffect.ToString().ToLower()
                );
                StaticFunctions.OpenConfig(configFolderPath + "/core_config.ini", out coreConfiguration);
            };
            buttons[3].OnPressed += () =>
            {
                parentSection = null;
                currentSection = Section.Menu;
                OpenSection();
            };
        }
    }
}