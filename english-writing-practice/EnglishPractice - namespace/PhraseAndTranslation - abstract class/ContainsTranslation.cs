using System;
using System.Linq;

namespace Treynessen.EnglishPractice
{
    public abstract partial class PhraseAndTranslation
    {
        public bool ContainsTranslation(string translation)
        {
            var found = Translations.FirstOrDefault(pt => pt.Phrase.Equals(translation, StringComparison.OrdinalIgnoreCase));
            return found != null;
        }

        public bool ContainsTranslation(PhraseAndTranslation translation)
        {
            return Translations.Contains(translation);
        }
    }
}