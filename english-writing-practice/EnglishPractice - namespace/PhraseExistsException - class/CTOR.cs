using System;

namespace Treynessen.EnglishPractice
{
    public class PhraseExistsException : Exception
    {
        public PhraseAndTranslation Phrase { get; }

        public PhraseExistsException(PhraseAndTranslation phrase, 
            string errMsg = "Phrase has already existed in Database") 
            : base(errMsg)
        {
            Phrase = phrase;
        }
    }
}