namespace Treynessen.EnglishPractice
{
    public partial class EnPhraseAndTranslation : PhraseAndTranslation
    {
        public override void Delete()
        {
            // В этом методе у объектов с переводом удаляется ссылка на текущий объект (this)
            // Если после удаления this у объектов с переводом их коллекция Translation не имеет объектов, тогда
            // у этих объектов вызывается метод Delete
            base.Delete();
            EnPhrasesDb.Remove(this);
        }
    }
}