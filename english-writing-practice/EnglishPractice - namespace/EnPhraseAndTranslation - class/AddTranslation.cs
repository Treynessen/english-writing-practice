using System;
using System.Linq;

namespace Treynessen.EnglishPractice
{
    public partial class EnPhraseAndTranslation : PhraseAndTranslation
    {
        public override void AddTranslation(string translation)
        {
            int translationListOldCount = Translations.Count();
            // В этом методе происходит связывание только с теми объектами, которые содержатся в БД
            base.AddTranslation(translation);
            if (translationListOldCount == Translations.Count())
            {
                // Если перевод не добавился, тогда проверяем содержался ли он уже в коллекции Translations
                if (Translations.Count() != 0)
                {
                    PhraseAndTranslation found = Translations.FirstOrDefault(pt => pt.Phrase.Equals(translation, StringComparison.OrdinalIgnoreCase));
                    if (found != null) return;
                }
                // Если перевода нет в Translations, значит этого объекта нет в translationsDb, поэтому необходимо создать его
                RuPhraseAndTranslation ruPhrase = new RuPhraseAndTranslation(translation, this, RuPhrasesDb, EnPhrasesDb);
                Translations.AddLast(ruPhrase);
            }
        }
    }
}