using System.IO;

namespace Treynessen.Functions
{
    public static partial class StaticFunctions
    {
        public static void SetFileContent(string path, string content, bool append = false)
        {
            using (StreamWriter writer = new StreamWriter(path, append))
            {
                writer.Write(content);
            }
        }
    }
}