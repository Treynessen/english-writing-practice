using System.Threading.Tasks;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        // Внутри метода Stop у объекта mainInterface
        // происходит вызов события OnStopped, который должен
        // каскадно вызывать методы Stop у зависимых интерфейсов
        // Поэтому у родительских интерфейсов необходимо привязать событие
        // OnStopped, которое будет вызывать метод Stop у производного интерфейса
        public void Stop()
        {
            mainInterface?.Stop();
        }
    }
}