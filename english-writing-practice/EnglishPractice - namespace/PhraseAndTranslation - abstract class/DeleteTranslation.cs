using System;
using System.Linq;

namespace Treynessen.EnglishPractice
{
    public abstract partial class PhraseAndTranslation
    {
        public virtual void DeleteTranslation(PhraseAndTranslation translation)
        {
            if (!activeValue)
            {
                throw new InvalidOperationException("This object has been deleted");
            }
            translation.Translations.Remove(this);
            Translations.Remove(translation);
            if (translation.Translations.Count() == 0)
            {
                translation.Delete();
            }
            if (Translations.Count() == 0)
            {
                Delete();
            }
        }
    }
}