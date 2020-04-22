using System;
using System.Collections.Generic;

namespace Treynessen.EnglishPractice
{
    [Serializable]
    public partial class RuPhraseAndTranslation : PhraseAndTranslation
    {
        private LinkedList<RuPhraseAndTranslation> RuPhrasesDb => phraseDb as LinkedList<RuPhraseAndTranslation>;
        private LinkedList<EnPhraseAndTranslation> EnPhrasesDb => translationDb as LinkedList<EnPhraseAndTranslation>;

        // Нет проверки наличия translation в БД, так как, если был передан объект translation, то он уже добавлен в БД
        // Если же объект translation был удален из БД, тогда будет брошено исключение ArgumentException
        public RuPhraseAndTranslation(string phrase, EnPhraseAndTranslation translation,
            LinkedList<RuPhraseAndTranslation> ruPhrasesDb, LinkedList<EnPhraseAndTranslation> enPhrasesDb)
            : base(phrase, translation, ruPhrasesDb, enPhrasesDb)
        {
            ruPhrasesDb.AddLast(this);
        }

        public RuPhraseAndTranslation(string phrase, string translation,
            LinkedList<RuPhraseAndTranslation> ruPhrasesDb, LinkedList<EnPhraseAndTranslation> enPhrasesDb)
            : base(phrase, ruPhrasesDb, enPhrasesDb)
        {
            AddTranslation(translation);
            ruPhrasesDb.AddLast(this);
        }

        public RuPhraseAndTranslation(string phrase, string[] translations,
            LinkedList<RuPhraseAndTranslation> ruPhrasesDb, LinkedList<EnPhraseAndTranslation> enPhrasesDb)
            : base(phrase, ruPhrasesDb, enPhrasesDb)
        {
            AddTranslation(translations);
            ruPhrasesDb.AddLast(this);
        }
    }
}