using System;
using System.Linq;

namespace Treynessen.EnglishPractice
{
    public abstract partial class PhraseAndTranslation
    {
        public virtual void Edit(string newPhrase)
        {
            if (!activeValue)
            {
                throw new InvalidOperationException("This object has been deleted");
            }
            if (string.IsNullOrEmpty(newPhrase))
            {
                throw new ArgumentException("newPhrase argument is undefined");
            }
            var found = phraseDb.FirstOrDefault(pt => pt.Phrase.Equals(newPhrase, StringComparison.OrdinalIgnoreCase));
            // Если объект с такой фразой уже существует, тогда удаляем текущий объект и переносим туда коллекцию Translations
            if (found != null)
            {
                foreach (var translate in Translations)
                {
                    found.AddTranslation(translate);
                }
                Delete();
            }
            else
            {
                Phrase = newPhrase;
            }
        }
    }
}