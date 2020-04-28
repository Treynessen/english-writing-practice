using System;
using Microsoft.Extensions.Configuration;
using Treynessen.UI;
using Treynessen.Functions;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private PhraseAndTranslationContainer dataContainer;

        private string programName;

        private Section currentSection;

        private IUserInterface currentInterface;
        private bool stopped = false;

        private ControlKeyContainer controlKeyContainer;
        private bool soundEffect = false;

        IConfiguration coreConfiguration;
        IConfiguration localization;

        public EnglishWritingPractice(PhraseAndTranslationContainer dataContainer)
        {
            this.dataContainer = dataContainer;
            StaticFunctions.OpenConfig(
                path: "config.ini",
                configuration: out coreConfiguration
            );
            StaticFunctions.OpenConfig(
                path: $"localizations/{coreConfiguration["lang"].ToLower()}_localization",
                configuration: out localization
            );
            programName = "Language writing practice";
            soundEffect = coreConfiguration["sound_effect"] != null && coreConfiguration["sound_effect"].Equals("true") ? true : false;
            controlKeyContainer = new ControlKeyContainer
            {
                LeftKey = ConsoleKey.LeftArrow,
                RightKey = ConsoleKey.RightArrow,
                UpKey = ConsoleKey.UpArrow,
                DownKey = ConsoleKey.DownArrow,
                EnterKey = ConsoleKey.Enter
            };
        }
    }
}