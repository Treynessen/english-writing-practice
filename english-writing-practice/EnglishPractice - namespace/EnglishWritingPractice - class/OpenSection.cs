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
                case Section.AddPhrase_LanguageChoice:
                    OpenAddPhrase_LanguageChoiceSection();
                    break;
                case Section.AddRuPhrase:
                    OpenAddPhraseSection<RuPhraseAndTranslation>();
                    break;
                case Section.AddEnPhrase:
                    OpenAddPhraseSection<EnPhraseAndTranslation>();
                    break;
                case Section.PhraseList_LanguageChoice:
                    OpenPhraseList_LanguageChoiceSection();
                    break;
                case Section.RuPhraseList:
                    OpenPhraseListSection<RuPhraseAndTranslation>();
                    break;
                case Section.EnPhraseList:
                    OpenPhraseListSection<EnPhraseAndTranslation>();
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