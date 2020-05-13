using System;

namespace Treynessen.UI
{
    public partial class ButtonInterface
    {
        public void Stop()
        {
            stopped = true;
            OnStopped?.Invoke(this, EventArgs.Empty);
        }
    }
}