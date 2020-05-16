using System;
using System.Linq;

namespace Treynessen.EnglishPractice
{
    public abstract partial class PhraseAndTranslation
    {
        private void AddTranslation(PhraseAndTranslation translation)
        {
            // Здесь нет проверки на activeValue, потому что этот метод используется только в конструкторе
            if (!translation.activeValue)
            {
                throw new ArgumentException("Passed translation parameter has been deleted");
            }
            if (!ContainsTranslation(translation))
            {
                Translations.AddLast(translation);
            }
        }

        // Связывает объект this и translation, если translation существует
        public virtual void AddTranslation(string translation)
        {
            if (!activeValue)
            {
                throw new InvalidOperationException("This object has been deleted");
            }
            // Если перевод содержится в коллекции Translation, тогда завершаем работу метода
            if (ContainsTranslation(translation)) return;
            var found = translationDb.FirstOrDefault(pt => pt.Phrase.Equals(translation, StringComparison.OrdinalIgnoreCase));
            if (found != null)
            {
                found.Translations.AddLast(this);
                Translations.AddLast(found);
            }
        }

        public virtual void AddTranslation(string[] translations)
        {
            foreach(var translation in translations)
            {
                AddTranslation(translation);
            }
        }
    }
}