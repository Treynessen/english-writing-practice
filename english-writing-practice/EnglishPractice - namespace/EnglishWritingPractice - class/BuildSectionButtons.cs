using System.Collections.Generic;
using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        // Получение кнопок для текущего раздела из файла с локализацией
        private void BuildSectionButtons()
        {
            var buttons = new LinkedList<LinkedList<string>>();
            var buttonsSection = localization.GetSection(currentSection.ToString());
            bool stop = false;
            for (int verticalLineId = 1; !stop; ++verticalLineId)
            {
                LinkedListNode<LinkedList<string>> node = null;
                for (int horizontalButtonId = 1; ; ++horizontalButtonId)
                {
                    string buttonName = buttonsSection[$"button_{verticalLineId}_{horizontalButtonId}"];
                    // Если не удалось получить следующую кнопку (больше кнопок в строке нет), тогда выходим из цикла
                    if (buttonName == null) break;
                    if (node == null)
                    {
                        node = buttons.AddLast(new LinkedList<string>());
                    }
                    node.Value.AddLast(buttonName);
                }
                if (node == null) stop = true;
            }
            this.buttons = new Buttons(buttons);
        }
    }
}