using System;
using System.Collections.Generic;

namespace Treynessen.UI
{
    public partial class TextInputtingInterface : IUserInterface
    {
        private VariableInfoPair[] variableInfoPairs;

        public event Action<IEnumerable<string>> OnGettingData;

        public TextInputtingInterface(VariableInfoPair[] variableInfoPairs)
        {
            this.variableInfoPairs = variableInfoPairs;
            Console.CursorVisible = true;
            Console.ForegroundColor = IUserInterface.DefaultTextColor;
            Console.BackgroundColor = IUserInterface.DefaultBackgroundColor;
        }
    }
}