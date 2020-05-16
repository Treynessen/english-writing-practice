namespace Treynessen.EnglishPractice
{
    public partial class Training
    {
        public Training AddEnPhrasesToQueue(int count)
        {
            AddPhrasesToQueue(dataContainer.EnPhrasesDb, count);
            return this;
        }
    }
}