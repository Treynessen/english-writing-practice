namespace Treynessen.EnglishPractice
{
    public partial class Training
    {
        public Training AddRuPhrasesToQueue(int count)
        {
            AddPhrasesToQueue(dataContainer.RuPhrasesDb, count);
            return this;
        }
    }
}