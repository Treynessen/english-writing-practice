namespace Treynessen.UI
{
    public partial class UserInterface
    {
        private void OpenSection()
        {
            verticalOperationNum = horizontalOperationNum = 1;
            switch (currentSection)
            {
                case Section.Menu:
                    BuildSectionButtons();
                    Menu_SetButtonsHandler();
                    ShowInterface();
                    break;
                case Section.Training:
                    break;
                case Section.AddPhrase:
                    break;
                case Section.PhraseList:
                    break;
                case Section.LocalizationSettings:
                    BuildLocalizationButtons();
                    ShowInterface();
                    break;
                case Section.SoundSettings:
                    BuildSectionButtons();
                    SoundSettings_SetButtonsHandler();
                    ShowInterface();
                    break;
            }
        }
    }
}