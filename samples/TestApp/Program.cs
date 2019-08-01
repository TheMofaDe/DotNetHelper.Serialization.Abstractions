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

            var schoolAsSerializeString = dataSource.SerializeToString(school); // SERIALIZE TO STRING
            var schoolObjectFromSerializeString = dataSource.Deserialize(schoolAsSerializeString, typeof(School)); // DESERIALIZE TO SCHOOL OBJECT
          
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
