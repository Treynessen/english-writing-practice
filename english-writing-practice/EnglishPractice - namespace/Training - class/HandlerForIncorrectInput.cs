using System;

namespace Treynessen.EnglishPractice
{
    public partial class Training
    {
        public void HandlerForIncorrectInput(Action<PhraseAndTranslation> actionWithPhrase = null)
        {
            var phraseNode = trainingPhrasesQueue.First;
            phraseNode.Value.CorrectAnswersSuccessively = 0;
            trainingPhrasesQueue.Remove(phraseNode);
            trainingPhrasesQueue.AddLast(phraseNode);
            actionWithPhrase?.Invoke(phraseNode.Value);
        }
    }
}