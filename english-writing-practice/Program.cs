using System.Collections.Generic;
using System.Runtime.InteropServices;
using Treynessen.EnglishPractice;

delegate void SignalHandler(ConsoleSignal consoleSignal);

enum ConsoleSignal
{
    CtrlC = 0,
    CtrlBreak = 1,
    Close = 2,
    LogOff = 5,
    Shutdown = 6
}

static class ConsoleHelper
{
    [DllImport("Kernel32", EntryPoint = "SetConsoleCtrlHandler")]
    public static extern bool SetSignalHandler(SignalHandler handler, bool add);
}

class Program
{
    static void Main()
    {
        LinkedList<RuPhraseAndTranslation> ruPhrasesDb = new LinkedList<RuPhraseAndTranslation>();
        LinkedList<EnPhraseAndTranslation> enPhrasesDb = new LinkedList<EnPhraseAndTranslation>();
        EnglishWritingPractice englishWritingPractice = new EnglishWritingPractice("config", ruPhrasesDb, enPhrasesDb);
        ConsoleHelper.SetSignalHandler(signal =>
        {
            if (signal == ConsoleSignal.CtrlBreak || signal == ConsoleSignal.Close
            || signal == ConsoleSignal.LogOff || signal == ConsoleSignal.Shutdown)
            {
                englishWritingPractice.Stop();
            }
        }, true);
        englishWritingPractice.Start();
    }
}