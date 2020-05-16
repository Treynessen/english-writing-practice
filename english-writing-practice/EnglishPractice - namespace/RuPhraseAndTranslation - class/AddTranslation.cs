using System;
using System.Linq;

namespace Treynessen.EnglishPractice
{
    public partial class RuPhraseAndTranslation : PhraseAndTranslation
    {
        public override void AddTranslation(string translation)
        {
            int translationListOldCount = Translations.Count();
            // В этом методе происходит связывание только с теми объектами, которые содержатся в БД
            base.AddTranslation(translation);
            if (translationListOldCount == Translations.Count())
            {
                // Если перевод не добавился, тогда проверяем содержался ли он уже в коллекции Translations
                if (ContainsTranslation(translation)) return;
                // Если перевода нет в Translations, значит этого объекта нет в translationsDb, поэтому необходимо создать его
                EnPhraseAndTranslation enPhrase = new EnPhraseAndTranslation(translation, this, EnPhrasesDb, RuPhrasesDb);
                Translations.AddLast(enPhrase);
            }
        }
    }
}