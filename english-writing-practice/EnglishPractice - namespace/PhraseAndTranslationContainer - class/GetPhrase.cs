using System.Linq;

namespace Treynessen.EnglishPractice
{
    public partial class PhraseAndTranslationContainer
    {
        public T GetPhrase<T>(string phrase) where T : PhraseAndTranslation
        {
            PhraseAndTranslation phraseObj = null;
            if (typeof(T) == typeof(RuPhraseAndTranslation))
            {
                phraseObj = RuPhrasesDb.FirstOrDefault(p => p.Phrase.Equals(phrase));
            }
            else
            {
                phraseObj = EnPhrasesDb.FirstOrDefault(p => p.Phrase.Equals(phrase));
            }
            return phraseObj as T;
        }
    }
}