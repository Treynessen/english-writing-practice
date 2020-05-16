using System;
using System.Linq;
using System.Threading.Tasks;

namespace Treynessen.UI
{
    public partial class TextInputtingInterface
    {
        public async Task Display()
        {
            await Task.Run(() =>
            {
                Console.Clear();
                Console.Title = getTitle();
                while (!stopped)
                {
                    OnBeforeTyping?.Invoke(this, EventArgs.Empty);
                    if (!stopped)
                    {
                        for (int i = 0; i < variableInfoPairs.Length; ++i)
                        {
                            Console.WriteLine($"{variableInfoPairs[i].Info}");
                            variableInfoPairs[i].Variable = Console.ReadLine();
                            if (string.IsNullOrEmpty(variableInfoPairs[i].Variable))
                            {
                                if (i == 0)
                                {
                                    Stop();
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
                    }
                    if (!stopped)
                    {
                        OnGettingData?.Invoke(variableInfoPairs.Select(vi => vi.Variable));
                        Console.WriteLine(successfulInputtingMsg);
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                if (!stopped)
                {
                    OnEnding?.Invoke(this, EventArgs.Empty);
                }
                Console.CursorVisible = false;
            });
        }
    }
}