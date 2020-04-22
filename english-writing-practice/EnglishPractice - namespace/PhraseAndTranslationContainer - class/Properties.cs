using System;
using System.Collections.Generic;

namespace Treynessen.EnglishPractice
{
    [Serializable]
    public class PhraseAndTranslationContainer
    {
        public LinkedList<RuPhraseAndTranslation> ruPhrasesDb { get; set; }
        public LinkedList<EnPhraseAndTranslation> enPhrasesDb { get; set; }
    }
}