using System;
using System.Linq;
using System.Threading.Tasks;

namespace Treynessen.UI
{
    public partial class TextInputtingInterface
    {
        public Task Display()
        {
            Console.Clear();
            bool withoutEvent = false;
            for (int i = 0; i < variableInfoPairs.Length; ++i)
            {
                Console.WriteLine($"{variableInfoPairs[i].Info}:");
                variableInfoPairs[i].Variable = Console.ReadLine();
                if (string.IsNullOrEmpty(variableInfoPairs[i].Variable))
                {
                    if (i == 0)
                    {
                        withoutEvent = true;
                        break;
                    }
                    else
                    {
                        for (int j = 0; j < i; ++j)
                        {
                            Console.WriteLine($"{variableInfoPairs[j].Info}:");
                            Console.WriteLine(variableInfoPairs[j].Variable);
                        }
                    }
                }
            }
            if (!withoutEvent)
            {
                OnGettingData(variableInfoPairs.Select(vi => vi.Variable));
            }
            return Task.CompletedTask;
        }
    }
}