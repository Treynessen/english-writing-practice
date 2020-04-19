using System.IO;
using Microsoft.Extensions.Configuration;

namespace Treynessen.Functions
{
    public static partial class StaticFunctions
    {
        public static void OpenConfig(string path, out IConfiguration configuration)
        {
            FileInfo config = new FileInfo(path);
            if (!config.Exists)
            {
                throw new FileNotFoundException($"{path} file doesn't exist");
            }
            configuration = new ConfigurationBuilder().AddIniFile(config.FullName).Build();
        }
    }
}