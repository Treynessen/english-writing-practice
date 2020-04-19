using System;

namespace Treynessen.UI
{
    public partial class Button
    {
        public void Press()
        {
            OnPressed?.Invoke();
        }
    }
}