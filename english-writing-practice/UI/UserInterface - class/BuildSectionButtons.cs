using System.Collections.Generic;

namespace Treynessen.UI
{
    public partial class UserInterface
    {
        // Получение кнопок для текущего раздела из файла с локализацией
        private void BuildSectionButtons()
        {
            var buttons = new LinkedList<LinkedList<string>>();
            var buttonsSection = localization.GetSection(currentSection.ToString());
            bool stop = false;
            for (int rowId = 1; !stop; ++rowId)
            {
                LinkedListNode<LinkedList<string>> node = null;
                for (int columnId = 1; ; ++columnId)
                {
                    string buttonName = buttonsSection[$"button_{rowId}_{columnId}"];
                    // Если не удалось получить следующую кнопку (больше кнопок в строке нет), тогда выходим из цикла
                    if (buttonName == null) break;
                    // Если в строке имеется 2 и более кнопок, тогда разрешаем горизонтальное управление
                    if (columnId == 2) horizontalControlAvailable = true;
                    if (node == null)
                    {
                        node = buttons.AddLast(new LinkedList<string>());
                    }
                    node.Value.AddLast(buttonName);
                }
                if (node == null) stop = true;
            }
            if (buttons.Count > 1)
            {
                verticalControlAvailable = true;
            }
            else
            {
                verticalControlAvailable = false;
            }
            this.buttons = new Buttons(buttons);
        }
    }
}