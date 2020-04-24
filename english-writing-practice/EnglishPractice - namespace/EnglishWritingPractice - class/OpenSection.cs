using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        // Тут собирается интерфейс для секции
        // Чтобы отобразить интерфейс необходимо вызвать метод currentInterface.Display()
        // Вызов этого метода происходит внутри задачи, которая создается в методе Start
        private void OpenSection()
        {
            switch (currentSection)
            {
                case Section.Menu:
                    OpenMenuSection();
                    break;
                case Section.Training:
                    break;
                case Section.AddPhrase:
                    OpenAddPhraseSection();
                    break;
                case Section.PhraseList:
                    break;
                case Section.LocalizationSettings:
                    OpenLocalizationSettingsSection();
                    break;
                case Section.SoundSettings:
                    OpenSoundSettingsSection();
                    break;
            }
        }
    }
}