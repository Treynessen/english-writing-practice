using System.Collections.Generic;

namespace Treynessen.EnglishPractice
{
    public partial class Training
    {
        private PhraseAndTranslationContainer dataContainer;
        private LinkedList<PhraseAndTranslation> trainingPhrasesQueue = new LinkedList<PhraseAndTranslation>();

        public bool EmptyQueue => trainingPhrasesQueue.Count == 0;

        public Training(PhraseAndTranslationContainer dataContainer)
        {
            this.dataContainer = dataContainer;
        }
    }
}