using System;
using Treynessen.Functions;

namespace Treynessen.UI
{
    public partial class UserInterface
    {
        private void SoundSettingsSection_ButtonsHandler()
        {
            switch (buttons.GetButtonNum(verticalOperationNum, horizontalOperationNum))
            {
                case 1:
                    soundEffect = true;
                    EditSoundEffectStringInConfig();
                    break;
                case 2:
                    soundEffect = false;
                    EditSoundEffectStringInConfig();
                    break;
                case 3:
                    parentSection = null;
                    currentSection = Section.Menu;
                    OpenSection();
                    break;
                default:
                    throw new InvalidOperationException($"Operation {(verticalOperationNum, horizontalOperationNum)} doesn't exist");
            }
        }

        private void EditSoundEffectStringInConfig()
        {
            string coreConfigPath = configFolderPath + "/core_config.ini";
            string configContent = StaticFunctions.GetFileContent(coreConfigPath);
            int beginIndex = configContent.IndexOf("sound_effect");
            if (beginIndex != -1)
            {
                int endIndex = configContent.IndexOf("\n", beginIndex);
                if (endIndex == -1) endIndex = configContent.Length;
                string soundEffectString = configContent.Substring(beginIndex, endIndex - beginIndex);
                configContent = configContent.Replace(soundEffectString, $"sound_effect={soundEffect.ToString().ToLower()}");
            }
            else
            {
                if (!configContent.EndsWith("\n"))
                {
                    configContent += "\n";
                }
                configContent += $"sound_effect={soundEffect}";
            }
            StaticFunctions.SetFileContent(configFolderPath + "/core_config.ini", configContent);
            OpenConfig("core_config.ini", ref coreConfiguration);
        }
    }
}