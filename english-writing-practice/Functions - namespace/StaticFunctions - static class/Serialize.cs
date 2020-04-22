using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Treynessen.Functions
{
    public static partial class StaticFunctions
    {
        public static void Serialize<T>(string path, T obj) where T : class
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                fs.Position = 0;
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, obj);
            }
        }
    }
}