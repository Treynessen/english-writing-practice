using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Treynessen.UI
{
    public partial class UserInterface
    {
        private string programName;

        private ConsoleColor defaultTextColor = ConsoleColor.DarkRed;
        private ConsoleColor defaultTextBackgroundColor = ConsoleColor.White;
        private ConsoleColor selectedTextColor = ConsoleColor.White;
        private ConsoleColor selectedTextBackgroundColor = ConsoleColor.DarkMagenta;

        private Section currentSection;
        private LinkedList<string> sectionButtons;

        private Task controlTask;
        private bool stopped = true;
        private int operationNum = 1;

        IConfiguration coreConfiguration;
        IConfiguration localization;

        private string configFolderPath;

        public UserInterface(string configFolderPath)
        {
            DirectoryInfo configFolder = new DirectoryInfo(configFolderPath);
            if (!configFolder.Exists)
            {
                throw new DirectoryNotFoundException("Config folder directory doesn't exist");
            }
            this.configFolderPath = configFolder.FullName;
            OpenConfig("core_config.ini", ref coreConfiguration);
            OpenConfig($"{coreConfiguration["lang"].ToLower()}_localization", ref localization);
            programName = "Language writing practice";
            Console.CursorVisible = false;
            Console.ForegroundColor = defaultTextColor;
            Console.BackgroundColor = defaultTextBackgroundColor;
        }
    }
}