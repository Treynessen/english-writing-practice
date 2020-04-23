using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void OpenSection()
        {
            switch (currentSection)
            {
                case Section.Menu:
                    BuildSectionButtons();
                    Menu_SetButtonHandlers();
                    currentInterface = new ButtonInterface(
                        buttons: buttons,
                        controlKeyContainer: controlKeyContainer,
                        getName: () => $"{programName} - {localization["Menu:SectionName"]}",
                        soundEffect: () => soundEffect
                    );
                    (currentInterface as ButtonInterface).StopAfterClickedEnterKey += () => true;
                    break;
                case Section.Training:
                    break;
                case Section.AddingPhrase:

                    break;
                case Section.PhraseList:
                    break;
                case Section.LocalizationSettings:
                    BuildLocalizationButtons();
                    currentInterface = new ButtonInterface(
                        buttons: buttons,
                        controlKeyContainer: controlKeyContainer,
                        getName: () => $"{programName} - {localization["LocalizationSettings:SectionName"]}",
                        soundEffect: () => soundEffect
                    );
                    (currentInterface as ButtonInterface).StopAfterClickedEnterKey += () =>
                    {
                        if (currentSection == Section.Menu) return true;
                        else return false;
                    };
                    break;
                case Section.SoundSettings:
                    BuildSectionButtons();
                    SoundSettings_SetButtonsHandler();
                    currentInterface = new ButtonInterface(
                        buttons: buttons,
                        controlKeyContainer: controlKeyContainer,
                        getName: () => $"{programName} - {localization["SoundSettings:SectionName"]}",
                        soundEffect: () => soundEffect
                    );
                    (currentInterface as ButtonInterface).StopAfterClickedEnterKey += () =>
                    {
                        if (currentSection == Section.Menu) return true;
                        else return false;
                    };
                    break;
            }
        }
    }
}