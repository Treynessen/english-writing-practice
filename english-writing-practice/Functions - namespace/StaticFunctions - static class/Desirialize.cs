using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Treynessen.Functions
{
    public static partial class StaticFunctions
    {
        public static T Desirialize<T>(string path) where T : class
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                fs.Position = 0;
                BinaryFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(fs) as T;
            }
        }
    }
}