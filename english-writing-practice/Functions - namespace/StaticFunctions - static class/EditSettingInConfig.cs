namespace Treynessen.Functions
{
    public static partial class StaticFunctions
    {
        public static void EditSettingInConfig(string path, string settingKey, string newValue)
        {
            string configContent = GetFileContent(path);
            int beginIndex = configContent.IndexOf(settingKey);
            if (beginIndex != -1)
            {
                int endIndex = configContent.IndexOf("\n", beginIndex);
                if (endIndex == -1) endIndex = configContent.Length;
                string settingString = configContent.Substring(beginIndex, endIndex - beginIndex);
                string newSettingString = $"{settingKey}={newValue}";
                configContent = configContent.Replace(settingString, newSettingString);
            }
            else
            {
                if (!configContent.EndsWith("\n"))
                {
                    configContent += "\n";
                }
                configContent += $"{settingKey}={newValue}";
            }
            SetFileContent(path, configContent);
        }
    }
}