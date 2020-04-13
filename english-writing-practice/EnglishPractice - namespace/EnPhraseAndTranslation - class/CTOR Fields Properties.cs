using System.Collections.Generic;

namespace Treynessen.EnglishPractice
{
    public partial class EnPhraseAndTranslation : PhraseAndTranslation
    {
        private LinkedList<EnPhraseAndTranslation> EnPhrasesDb => phraseDb as LinkedList<EnPhraseAndTranslation>;
        private LinkedList<RuPhraseAndTranslation> RuPhrasesDb => translationDb as LinkedList<RuPhraseAndTranslation>;

        // Нет проверки наличия translation в БД, так как, если был передан объект translation, то он уже добавлен в БД
        // Если же объект translation был удален из БД, тогда будет брошено исключение ArgumentException
        public EnPhraseAndTranslation(string phrase, RuPhraseAndTranslation translation,
            LinkedList<EnPhraseAndTranslation> enPhrasesDb, LinkedList<RuPhraseAndTranslation> ruPhrasesDb)
            : base(phrase, translation, enPhrasesDb, ruPhrasesDb)
        {
            enPhrasesDb.AddLast(this);
        }

        public EnPhraseAndTranslation(string phrase, string translation,
            LinkedList<EnPhraseAndTranslation> enPhrasesDb, LinkedList<RuPhraseAndTranslation> ruPhrasesDb)
            : base(phrase, enPhrasesDb, ruPhrasesDb)
        {
            AddTranslation(translation);
            enPhrasesDb.AddLast(this);
        }

        public EnPhraseAndTranslation(string phrase, string[] translations,
            LinkedList<EnPhraseAndTranslation> enPhrasesDb, LinkedList<RuPhraseAndTranslation> ruPhrasesDb)
            : base(phrase, enPhrasesDb, ruPhrasesDb)
        {
            AddTranslation(translations);
            enPhrasesDb.AddLast(this);
        }

    }
}