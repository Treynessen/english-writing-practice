using System;
using System.Linq;

namespace Treynessen.EnglishPractice
{
    public abstract partial class PhraseAndTranslation
    {
        public virtual void Delete()
        {
            if (!activeValue)
            {
                throw new InvalidOperationException("This object has been deleted");
            }
            activeValue = false;
            foreach (var translation in Translations)
            {
                translation.Translations.Remove(this);
                if (translation.Translations.Count() == 0)
                {
                    translation.Delete();
                }
            }
        }
    }
}
