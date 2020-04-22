using System.Collections.Generic;

namespace Treynessen.EnglishPractice
{
    public partial class EnPhraseAndTranslation : PhraseAndTranslation
    {
        public static EnPhraseAndTranslation Create(string phrase, RuPhraseAndTranslation translation,
            LinkedList<EnPhraseAndTranslation> enPhrasesDb, LinkedList<RuPhraseAndTranslation> ruPhrasesDb)
        {
            return new EnPhraseAndTranslation(phrase, translation, enPhrasesDb, ruPhrasesDb);
        }

        public static EnPhraseAndTranslation Create(string phrase, string translation,
            LinkedList<EnPhraseAndTranslation> enPhrasesDb, LinkedList<RuPhraseAndTranslation> ruPhrasesDb)
        {
            return new EnPhraseAndTranslation(phrase, translation, enPhrasesDb, ruPhrasesDb);
        }

        public static EnPhraseAndTranslation Create(string phrase, string[] translations,
            LinkedList<EnPhraseAndTranslation> enPhrasesDb, LinkedList<RuPhraseAndTranslation> ruPhrasesDb)
        {
            return new EnPhraseAndTranslation(phrase, translations, enPhrasesDb, ruPhrasesDb);
        }
    }
}