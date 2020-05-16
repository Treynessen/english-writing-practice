using System;

namespace Treynessen.EnglishPractice
{
    public partial class Training
    {
        public PhraseAndTranslation GetPhrase()
        {
            if (trainingPhrasesQueue.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return trainingPhrasesQueue.First.Value;
        }
    }
}