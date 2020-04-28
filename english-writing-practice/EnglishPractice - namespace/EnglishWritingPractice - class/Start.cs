using System.Threading.Tasks;

namespace Treynessen.EnglishPractice
{
    public partial class EnglishWritingPractice
    {
        public Task Start(bool innerWaiting = true)
        {
            Task programTask = Task.Run(async () =>
            {
                currentSection = Section.Menu;
                while (!stopped)
                {
                    OpenSection();
                    await currentInterface?.Display();
                }
            });
            if (innerWaiting)
            {
                programTask.Wait();
                return Task.CompletedTask;
            }
            else return programTask;
        }
    }
}