using System;

namespace Treynessen.UI
{
    public partial class Button
    {
        public string Name { get; private set; }
        public event Action OnPressed;

        public Button(string name)
        {
            Name = name;
        }
    }
}