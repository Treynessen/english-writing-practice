using System.IO;

namespace Treynessen.Functions
{
    public static partial class StaticFunctions
    {
        public static string GetFileContent(string path)
        {
            string content = null;
            using (StreamReader reader = new StreamReader(path))
            {
                content = reader.ReadToEnd();
            }
            return content;
        }
    }
}