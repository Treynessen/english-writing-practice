using System;

namespace Treynessen.UI
{
    public partial class Button
    {
        public string Name { get; private set; }
        public bool Active { get; set; }
        public event EventHandler OnPressed;

        public Button(string name, bool active = true)
        {
            Name = name;
            Active = active;
        }
    }
}