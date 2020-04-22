using System.Collections.Generic;

namespace Treynessen.EnglishPractice
{
    public partial class RuPhraseAndTranslation : PhraseAndTranslation
    {
        public static RuPhraseAndTranslation Create(string phrase, EnPhraseAndTranslation translation,
            LinkedList<RuPhraseAndTranslation> ruPhrasesDb, LinkedList<EnPhraseAndTranslation> enPhrasesDb)
        {
            return new RuPhraseAndTranslation(phrase, translation, ruPhrasesDb, enPhrasesDb);
        }

        public static RuPhraseAndTranslation Create(string phrase, string translation,
            LinkedList<RuPhraseAndTranslation> ruPhrasesDb, LinkedList<EnPhraseAndTranslation> enPhrasesDb)
        {
            return new RuPhraseAndTranslation(phrase, translation, ruPhrasesDb, enPhrasesDb);
        }

        public static RuPhraseAndTranslation Create(string phrase, string[] translations,
            LinkedList<RuPhraseAndTranslation> ruPhrasesDb, LinkedList<EnPhraseAndTranslation> enPhrasesDb)
        {
            return new RuPhraseAndTranslation(phrase, translations, ruPhrasesDb, enPhrasesDb);
        }
    }
}