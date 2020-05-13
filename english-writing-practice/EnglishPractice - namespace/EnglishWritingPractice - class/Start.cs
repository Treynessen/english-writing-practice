using System.Threading.Tasks;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        public Task Start(bool innerWaiting = true)
        {
            mainInterface = BuildMenuSection();
            Task mainTask = mainInterface.Display();
            if(!innerWaiting)
            {
                return mainTask;
            }
            mainTask.Wait();
            return Task.CompletedTask;
        }
    }
}