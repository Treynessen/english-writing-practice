using System;

namespace Treynessen.EnglishPractice
{
    public partial class Training
    {
        public void HandlerForCorrectInput(Action<PhraseAndTranslation> actionWithPhrase = null)
        {
            var phraseNode = trainingPhrasesQueue.First;
            ++phraseNode.Value.CorrectAnswersSuccessively;
            trainingPhrasesQueue.Remove(phraseNode);
            actionWithPhrase?.Invoke(phraseNode.Value);
        }
    }
}