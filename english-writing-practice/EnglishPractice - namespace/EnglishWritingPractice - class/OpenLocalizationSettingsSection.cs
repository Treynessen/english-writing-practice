﻿using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Treynessen.UI;
using Treynessen.Functions;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void OpenLocalizationSettingsSection()
        {
            Buttons buttons= BuildLocalizationButtons();
            currentInterface = new ButtonInterface(
                buttons: buttons,
                controlKeyContainer: controlKeyContainer,
                getTitle: () => $"{programName} - {localization["LocalizationSettings:SectionName"]}",
                soundEffect: () => soundEffect
            );
            (currentInterface as ButtonInterface).StopAfterClickedEnterKey += () => currentSection != Section.LocalizationSettings;
        }

        private Buttons BuildLocalizationButtons()
        {
            var localizationPaths = Directory.GetFiles("localizations", "*_localization");
            LinkedList<LinkedList<Button>> buttons = new LinkedList<LinkedList<Button>>();
            foreach (var localizationPath in localizationPaths)
            {
                // Открываем файл с локализацией и получаем название локализации
                StaticFunctions.OpenConfig(
                    path: localizationPath,
                    configuration: out IConfiguration localizationConfig
                );
                string localizationName = localizationConfig["Name"];
                Button button = new Button(localizationName);
                button.OnPressed += () =>
                {
                    StaticFunctions.OpenConfig(
                        path: localizationPath,
                        configuration: out localization
                    );
                    // Изменяем значение ключа lang в core_config
                    Regex regex = new Regex(@"(?<lang>\w+)_localization$");
                    StaticFunctions.EditSettingInConfig(
                        path: "config.ini",
                        settingKey: "lang",
                        newValue: regex.Match(localizationPath).Groups[1].Value
                    );
                    StaticFunctions.OpenConfig(
                        path: "config.ini",
                        configuration: out coreConfiguration
                    );
                    // Изменяем название кнопки назад в зависимости от текущей локализации
                    if (currentInterface is ButtonInterface buttonInterface)
                    {
                        buttonInterface.Buttons[buttonInterface.Buttons.Count].Rename(localization["LocalizationSettings:button_1_1"]);
                    }
                };
                buttons.AddLast(new LinkedList<Button>()).Value.AddLast(button);
            }
            Button backButton = new Button(localization["LocalizationSettings:button_1_1"]);
            backButton.OnPressed += () => currentSection = Section.Menu;
            buttons.AddLast(new LinkedList<Button>()).Value.AddLast(backButton);
            return new Buttons(buttons);
        }
    }
}