using System;
using System.Linq;
using System.Collections.Generic;

namespace Treynessen.EnglishPractice
{
    [Serializable]
    public abstract partial class PhraseAndTranslation
    {
        private bool activeValue = true;
        public bool Deleted => !activeValue;

        protected IEnumerable<PhraseAndTranslation> phraseDb;
        protected IEnumerable<PhraseAndTranslation> translationDb;

        public string Phrase { get; private set; }
        public LinkedList<PhraseAndTranslation> Translations { get; }

        public int CorrectAnswersSuccessively { get; set; }

        public PhraseAndTranslation(string phrase, IEnumerable<PhraseAndTranslation> phraseDb,
            IEnumerable<PhraseAndTranslation> translationDb)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                throw new ArgumentException("Passed phrase argument is undefined");
            }
            if (phraseDb == null)
            {
                throw new ArgumentException("Passed phraseDb argument is undefined");
            }
            this.phraseDb = phraseDb;
            if (translationDb == null)
            {
                throw new ArgumentException("Passed translationDb argument is undefined");
            }
            this.translationDb = translationDb;
            var found = phraseDb.FirstOrDefault(p => p.Phrase.Equals(phrase, StringComparison.OrdinalIgnoreCase));
            if (found != null)
            {
                throw new PhraseExistsException(found);
            }
            Phrase = phrase;
            Translations = new LinkedList<PhraseAndTranslation>();
        }

        public PhraseAndTranslation(string phrase, PhraseAndTranslation translation,
            IEnumerable<PhraseAndTranslation> phraseDb, IEnumerable<PhraseAndTranslation> translationDb)
            : this(phrase, phraseDb, translationDb)
        {
            AddTranslation(translation);
        }
    }
}