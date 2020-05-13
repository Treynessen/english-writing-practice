using Treynessen.Functions;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void DeserializeDataContainer()
        {
            dataContainer = StaticFunctions.Desirialize<PhraseAndTranslationContainer>(dictionaryPath);
        }

    }
}