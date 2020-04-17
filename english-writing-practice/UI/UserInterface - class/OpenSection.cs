using System;
using System.Threading.Tasks;

namespace Treynessen.UI
{
    public partial class UserInterface
    {
        private void OpenSection()
        {
            operationNum = 1;
            switch (currentSection)
            {
                case Section.Menu:
                    BuildSectionButtons();
                    ShowInterface();
                    break;
                case Section.Training:
                    break;
                case Section.AddPhrase:
                    break;
                case Section.PhraseList:
                    break;
                case Section.LocalizationSettings:
                    break;
                case Section.SoundSettings:
                    BuildSectionButtons();
                    ShowInterface();
                    break;
            }
        }
    }
}