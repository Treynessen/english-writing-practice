using System;
using System.Collections.Generic;

namespace Treynessen.EnglishPractice
{
    [Serializable]
    public class PhraseAndTranslationContainer
    {
        public LinkedList<RuPhraseAndTranslation> RuPhrasesDb { get; set; }
        public LinkedList<EnPhraseAndTranslation> EnPhrasesDb { get; set; }
    }
}