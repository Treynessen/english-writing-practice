using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Treynessen.UI;
using Treynessen.Functions;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private PhraseAndTranslationContainer dataContainer;

        private string programName = "Language writing practice";

        private IUserInterface mainInterface;

        private ControlKeyContainer controlKeyContainer;

        private bool withSoundEffect;

        private string dictionaryPath;
        private IConfiguration coreConfiguration;
        private IConfiguration localization;


        public EnglishWritingPractice(string dictionaryPath)
        {
            Console.Title = programName;
            StaticFunctions.OpenConfig(
                path: "config.ini",
                configuration: out coreConfiguration
            );
            StaticFunctions.OpenConfig(
                path: $"localizations/{coreConfiguration["lang"].ToLower()}_localization",
                configuration: out localization
            );
            if (string.IsNullOrEmpty(dictionaryPath) || !File.Exists(dictionaryPath))
            {
                Console.WriteLine(localization["preload:dictionary_not_found"]);
                Console.WriteLine(localization["preload:new_dictionary_has_created"]);
                Console.Write(localization["common:press_any_key_to_continue"]);
                Console.ReadKey();
                this.dictionaryPath = "dictionary.data";
            }
            else
            {
                this.dictionaryPath = dictionaryPath;
                DeserializeDataContainer();
            }
            withSoundEffect = Convert.ToBoolean(coreConfiguration["sound_effect"]);
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