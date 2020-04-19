using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Treynessen.Functions;
using Treynessen.EnglishPractice;

namespace Treynessen.UI
{
    public partial class UserInterface
    {
        private LinkedList<RuPhraseAndTranslation> ruPhrasesDb;
        private LinkedList<EnPhraseAndTranslation> enPhrasesDb;

        private string programName;

        private ConsoleColor defaultTextColor = ConsoleColor.DarkRed;
        private ConsoleColor defaultTextBackgroundColor = ConsoleColor.White;
        private ConsoleColor selectedTextColor = ConsoleColor.White;
        private ConsoleColor selectedTextBackgroundColor = ConsoleColor.DarkMagenta;

        private Section? parentSection;
        private Section currentSection;
        private Buttons buttons;

        private Task controlTask;
        private bool stopped = true;

        private int verticalOperationNum = 1;
        private int horizontalOperationNum = 1;

        private bool soundEffect = false;

        IConfiguration coreConfiguration;
        IConfiguration localization;

        private string configFolderPath;

        public UserInterface(string configFolderPath, LinkedList<RuPhraseAndTranslation> ruPhrasesDb, LinkedList<EnPhraseAndTranslation> enPhrasesDb)
        {
            this.ruPhrasesDb = ruPhrasesDb;
            this.enPhrasesDb = enPhrasesDb;
            DirectoryInfo configFolder = new DirectoryInfo(configFolderPath);
            if (!configFolder.Exists)
            {
                throw new DirectoryNotFoundException("Config folder directory doesn't exist");
            }
            this.configFolderPath = configFolder.FullName;
            StaticFunctions.OpenConfig(
                path: $"{this.configFolderPath}/core_config.ini",
                configuration: out coreConfiguration
            );
            StaticFunctions.OpenConfig(
                path: $"{this.configFolderPath}/{coreConfiguration["lang"].ToLower()}_localization",
                configuration: out localization
            );
            programName = "Language writing practice";
            soundEffect = coreConfiguration["sound_effect"] != null && coreConfiguration["sound_effect"].Equals("true") ? true : false;
            Console.CursorVisible = false;
            Console.ForegroundColor = defaultTextColor;
            Console.BackgroundColor = defaultTextBackgroundColor;
        }
    }
}