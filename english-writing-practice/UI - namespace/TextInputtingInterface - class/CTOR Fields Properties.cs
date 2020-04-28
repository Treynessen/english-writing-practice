using System;
using System.Collections.Generic;

namespace Treynessen.UI
{
    public partial class TextInputtingInterface : IUserInterface
    {
        private VariableInfoPair[] variableInfoPairs;
        private string successfulInputtingMsg;

        public event Action<IEnumerable<string>> OnGettingData;
        public event Action OnEnding;

        public TextInputtingInterface(VariableInfoPair[] variableInfoPairs, string successfulInputtingMsg, Func<string> getTitle)
        {
            this.variableInfoPairs = variableInfoPairs;
            this.successfulInputtingMsg = successfulInputtingMsg;
            Console.Title = getTitle();
            Console.CursorVisible = true;
            Console.ForegroundColor = IUserInterface.DefaultTextColor;
            Console.BackgroundColor = IUserInterface.DefaultBackgroundColor;
        }
    }
}