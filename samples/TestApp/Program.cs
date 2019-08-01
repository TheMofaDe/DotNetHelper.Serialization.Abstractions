using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using DotNetHelper.Serialization.Abstractions;

namespace TestApp
{
    class Program
    {
        [Serializable]
        public class School
        {
            public string Name { get; set; } = "Woodland";
            public string City { get; set; } = "Cartersville";
        }
        static void Main(string[] args)
        {
            var dataSource = new DataSourceBinary();
            var school = new School();


            var serializer = new BinaryFormatter();
            var memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, school);
            memoryStream.Seek(0, SeekOrigin.Begin);

          //  var asString = new StreamReader(memoryStream,Encoding.UTF8).ReadToEnd();
            var asString = Convert.ToBase64String(memoryStream.ToArray());
            var backTOStream = ToStream(asString, Encoding.UTF8);

            var bytes = Convert.FromBase64String(new StreamReader(backTOStream,Encoding.UTF8).ReadToEnd());
            backTOStream = new MemoryStream(bytes);
          //  var contents = new StreamContent(new MemoryStream(bytes));


            var deserialize22 = serializer.Deserialize(backTOStream);
            var deserialize = serializer.Deserialize(memoryStream);

            
        



            var serializeString = dataSource.SerializeToString(school);
            var deSerializeObj = dataSource.Deserialize(serializeString, typeof(School));

            Console.WriteLine("Hello World!");
            Console.Read();
        }

        public static Stream ToStream( string s, Encoding encoding)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream, encoding, 1024, false);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
