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
                    DefaultSectionHandler();
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
                    DefaultSectionHandler();
                    break;
            }
        }
    }
}