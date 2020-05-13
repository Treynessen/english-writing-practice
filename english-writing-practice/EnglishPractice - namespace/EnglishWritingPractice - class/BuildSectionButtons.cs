using System;
using System.Linq;
using System.Text.RegularExpressions;
using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        // Получение кнопок для текущего раздела из файла с локализацией
        private Buttons BuildSectionButtons(string sectionName)
        {
            Buttons buttons = new Buttons();
            Regex regex = new Regex(@"^button_(?<verticalLineId>\d+)_(?<horizontalButtonId>\d+)$", RegexOptions.IgnoreCase);
            var buttonDatas = from section in localization.GetSection(sectionName).GetChildren()
                              let match = regex.Match(section.Key)
                              where match.Success
                              let verticalLineId = Convert.ToInt32(match.Groups["verticalLineId"].Value)
                              let horizontalButtonId = Convert.ToInt32(match.Groups["horizontalButtonId"].Value)
                              orderby verticalLineId, horizontalButtonId
                              select new { verticalLineId, horizontalButtonId, Name = section.Value };
            foreach (var buttonData in buttonDatas)
            {
                buttons.AddButton(
                    buttonPosition: (buttonData.verticalLineId, buttonData.horizontalButtonId),
                    button: new Button(buttonData.Name)
                );
            }
            return buttons;
        }
    }
}