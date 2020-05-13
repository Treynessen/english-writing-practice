using System;
using Treynessen.UI;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        private void ConnectStoppedEvents(IUserInterface superInterface, IUserInterface subInterface)
        {
            EventHandler onStopped = (o, args) => subInterface.Stop();
            superInterface.OnStopped += onStopped;
            // При выходе из интерфейса необходимо отвязать событие onStopped от superInterface
            subInterface.OnStopped += (o, args) =>
            {
                superInterface.OnStopped -= onStopped;
            };
        }
    }
}