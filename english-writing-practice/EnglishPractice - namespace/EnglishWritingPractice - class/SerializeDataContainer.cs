using Treynessen.Functions;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void SerializeDataContainer()
        {
            StaticFunctions.Serialize(
                path: dictionaryPath,
                obj: dataContainer
            );
        }

    }
}