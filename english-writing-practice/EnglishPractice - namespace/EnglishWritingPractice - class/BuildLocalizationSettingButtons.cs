using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Treynessen.UI;
using Treynessen.Functions;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        // Тут не создается кнопка "Назад"
        private Buttons BuildLocalizationSettingButtons()
        {
            var localizationPaths = Directory.GetFiles("localizations", "*_localization");
            Buttons buttons = new Buttons();
            foreach (var localizationPath in localizationPaths)
            {
                // Открываем файл с локализацией и получаем название локализации
                StaticFunctions.OpenConfig(
                    path: localizationPath,
                    configuration: out IConfiguration _localization
                );
                string localizationName = _localization["localization_name"];
                Button button = new Button(localizationName);
                button.OnPressed += (o, args) =>
                {
                    localization = _localization;
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
                    buttons[buttons.ButtonCount].Rename(localization["LocalizationSettings:button_1_1"]);
                };
                buttons.AddButton(buttons.VerticalLineCount + 1, 1, button);
            }
            return buttons;
        }
    }
}
