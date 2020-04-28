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
            bool exitInterface = false;
            while (!exitInterface)
            {
                for (int i = 0; i < variableInfoPairs.Length; ++i)
                {
                    Console.WriteLine($"{variableInfoPairs[i].Info}");
                    variableInfoPairs[i].Variable = Console.ReadLine();
                    if (string.IsNullOrEmpty(variableInfoPairs[i].Variable))
                    {
                        if (i == 0)
                        {
                            exitInterface = true;
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            int j = 0;
                            for (; j < i - 1; ++j)
                            {
                                Console.WriteLine($"{variableInfoPairs[j].Info}");
                                Console.WriteLine(variableInfoPairs[j].Variable);
                            }
                            i = i - 2;
                        }
                    }
                }
                if (!exitInterface)
                {
                    OnGettingData?.Invoke(variableInfoPairs.Select(vi => vi.Variable));
                    Console.WriteLine(successfulInputtingMsg);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            Console.CursorVisible = false;
            OnEnding?.Invoke();
            return Task.CompletedTask;
        }
    }
}