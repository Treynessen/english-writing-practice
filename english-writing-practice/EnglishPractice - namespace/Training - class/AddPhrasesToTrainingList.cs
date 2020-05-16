using System;
using System.Linq;
using System.Collections.Generic;

namespace Treynessen.EnglishPractice
{
    public partial class Training
    {
        private void AddPhrasesToQueue(IEnumerable<PhraseAndTranslation> phrases, int count)
        {
            int phrasesCount = phrases.Count();
            if (count > phrasesCount)
            {
                throw new IndexOutOfRangeException("Count argument is more than count of phrases in db");
            }
            // Получаем список индексов в коллекции phrases
            LinkedList<int> indexes = new LinkedList<int>();
            for (int phraseIndex = 0; phraseIndex < phrasesCount; ++phraseIndex)
            {
                indexes.AddLast(phraseIndex);
            }
            Random rand = new Random();
            for (int i = 0; i < count; ++i)
            {
                // Получаем случайный индекс из коллекции indexes
                LinkedListNode<int> indexNode = null;
                for (int index = 0; index <= rand.Next(0, indexes.Count); ++index)
                {
                    if (indexNode == null) indexNode = indexes.First;
                    else indexNode = indexNode.Next;
                }
                // Получаем фразу по индексу
                trainingPhrasesQueue.AddLast(phrases.ElementAt(indexNode.Value));
                // Удаляем индекс из коллекции indexes, чтобы избежать повторения фраз
                indexes.Remove(indexNode);
            }
        }
    }
}