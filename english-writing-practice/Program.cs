using System.Collections.Generic;
using Treynessen.EnglishPractice;

class Program
{
    static void Main()
    {
        LinkedList<RuPhraseAndTranslation> ruPhrasesDb = new LinkedList<RuPhraseAndTranslation>();
        LinkedList<EnPhraseAndTranslation> enPhrasesDb = new LinkedList<EnPhraseAndTranslation>();
        RuPhraseAndTranslation ruPhrase = new RuPhraseAndTranslation("Привет", "Hello", ruPhrasesDb, enPhrasesDb);
        ruPhrase.AddTranslation("Hey");
        enPhrasesDb.First.Value.Edit("hey");
        ruPhrase.Delete();
    }
}