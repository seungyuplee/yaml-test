using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace yaml_test
{
    public class FileController
    {
        static FileController()
        {
            Instance = new FileController();
        }

        private FileController()
        {

        }

        public static FileController Instance { get; }

        public void Serialize<T>(string fileName, T value)
        {
            var builder = new SerializerBuilder().Build();

            using (var stream = File.Create(fileName))
            {
                using (var writer = new StreamWriter(stream))
                {
                    builder.Serialize(writer, value);
                }
            }
        }

        public T DeSerialize<T>(string fileName) where T : class
        {
            var builder = new DeserializerBuilder().Build();

            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(stream))
                {
                    return builder.Deserialize(reader, typeof(T)) as T;
                }
            }
        }
    }
}
