using System;

namespace Treynessen.UI
{
    public partial interface IUserInterface
    {
        protected static ConsoleColor DefaultTextColor => ConsoleColor.DarkRed;
        protected static ConsoleColor DefaultBackgroundColor => ConsoleColor.White;
    }
}