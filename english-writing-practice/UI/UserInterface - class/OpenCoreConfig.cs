using System.IO;
using Microsoft.Extensions.Configuration;

namespace Treynessen.UI
{
    public partial class UserInterface
    {
        private void OpenConfig(string configFileName, ref IConfiguration configuration)
        {
            FileInfo config = new FileInfo(configFolderPath + $"/{configFileName}");
            if (!config.Exists)
            {
                throw new FileNotFoundException($"{configFileName} file doesn't exist");
            }
            configuration = new ConfigurationBuilder().AddIniFile(config.FullName).Build();
        }
    }
}