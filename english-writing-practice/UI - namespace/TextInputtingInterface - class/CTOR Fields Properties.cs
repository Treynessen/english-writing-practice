using System;
using System.Collections.Generic;

namespace Treynessen.UI
{
    public partial class TextInputtingInterface : IUserInterface
    {
        private Func<string> getTitle;

        private bool stopped = false;

        private VariableInfoPair[] variableInfoPairs;
        private string successfulInputtingMsg;

        public event Action<IEnumerable<string>> OnGettingData;
        public event EventHandler OnEnding;
        public event EventHandler OnStopped;

        public TextInputtingInterface(VariableInfoPair[] variableInfoPairs, string successfulInputtingMsg, Func<string> getTitle)
        {
            this.variableInfoPairs = variableInfoPairs;
            this.successfulInputtingMsg = successfulInputtingMsg;
            this.getTitle = getTitle;
            Console.CursorVisible = true;
            Console.ForegroundColor = IUserInterface.DefaultTextColor;
            Console.BackgroundColor = IUserInterface.DefaultBackgroundColor;
        }
    }
}