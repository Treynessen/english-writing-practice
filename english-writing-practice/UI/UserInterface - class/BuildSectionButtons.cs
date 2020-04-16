using System.Collections.Generic;

namespace Treynessen.UI
{
    public partial class UserInterface
    {
        private void BuildSectionButtons()
        {
            sectionButtons = new LinkedList<string>();
            foreach (var buttonName in localization.GetSection(currentSection.ToString()).GetChildren())
            {
                if (!buttonName.Key.Equals("SectionName"))
                {
                    sectionButtons.AddLast(buttonName.Value);
                }
            }
        }
    }
}