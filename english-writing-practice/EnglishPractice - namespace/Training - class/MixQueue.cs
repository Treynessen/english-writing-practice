using System;
using System.Collections.Generic;

namespace Treynessen.EnglishPractice
{
    public partial class Training
    {
        public Training MixQueue()
        {
            if (trainingPhrasesQueue != null && trainingPhrasesQueue.Count > 1)
            {
                LinkedList<PhraseAndTranslation> newTrainingPhrasesQueue = new LinkedList<PhraseAndTranslation>();
                Random rand = new Random();
                while (trainingPhrasesQueue.Count != 0)
                {
                    LinkedListNode<PhraseAndTranslation> queueNode = null;
                    for (int queueIndex = 0; queueIndex <= rand.Next(0, trainingPhrasesQueue.Count); ++queueIndex)
                    {
                        if (queueNode == null) queueNode = trainingPhrasesQueue.First;
                        else queueNode = queueNode.Next;
                    }
                    newTrainingPhrasesQueue.AddLast(queueNode);
                    trainingPhrasesQueue.Remove(queueNode);
                }
                trainingPhrasesQueue = newTrainingPhrasesQueue;
            }
            return this;
        }
    }
}