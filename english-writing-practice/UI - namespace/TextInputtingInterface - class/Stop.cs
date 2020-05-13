using System;

namespace Treynessen.UI
{
    public partial class TextInputtingInterface
    {
        public void Stop()
        {
            stopped = true;
            OnStopped?.Invoke(this, EventArgs.Empty);
        }
    }
}