using System;
using System.Runtime.InteropServices;
using Treynessen.UI;
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
        UserInterface userInterface = new UserInterface("config");
        //ConsoleHelper.SetSignalHandler(signal =>
        //{
        //    if(signal == ConsoleSignal.CtrlBreak || signal == ConsoleSignal.Close 
        //    || signal == ConsoleSignal.LogOff || signal == ConsoleSignal.Shutdown)
        //    {
        //        userInterface.Stop();
        //    }
        //}, true);
        userInterface.Start();
    }
}