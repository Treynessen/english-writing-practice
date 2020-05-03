using Treynessen.Functions;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void SerializeDataContainer()
        {

            StaticFunctions.Serialize(
                path: "dictionary.data",
                obj: dataContainer
            );
        }
    }
}