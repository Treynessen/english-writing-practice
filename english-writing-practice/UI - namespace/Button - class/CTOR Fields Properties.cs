using System;

namespace Treynessen.UI
{
    public partial class Button
    {
        public string Name { get; private set; }
        public bool Active { get; set; } = true;
        public event EventHandler OnPressed;

        public Button(string name)
        {
            Name = name;
        }
    }
}