using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using DotNetHelper.Serialization.Abstractions.Extension;
using DotNetHelper.Serialization.Abstractions.Interface;

namespace DotNetHelper.Serialization.Abstractions
{
    public class DataSourceBinary : ISerializer
    {
        public BinaryFormatter Formatter { get; }
        /// <summary>
        /// Gets or sets the encoding.
        /// </summary>
        /// <value>The encoding.</value>
        public Encoding Encoding { get; set; }

        public DataSourceBinary(Encoding encoding, BinaryFormatter b = null)
        {
            Formatter = b ?? new BinaryFormatter();
            Encoding = encoding ?? Encoding.UTF8;
        }
        public DataSourceBinary()
        {
            Formatter = new BinaryFormatter();
            Encoding = Encoding.UTF8;
        }
          


        public void SerializeToStream<T>(T obj, Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false) where T : class
        {
            SerializeToStream(obj, typeof(T), stream, bufferSize, leaveStreamOpen);
        }

        public void SerializeToStream(object obj, Type type, Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false)
        { 
            obj.IsNullThrow(nameof(obj));
            Formatter.Serialize(stream, obj);
            if (!leaveStreamOpen) stream.Dispose();
        }

        public Stream SerializeToStream(object obj, Type type, int bufferSize = 1024)
        {
            obj.IsNullThrow(nameof(obj));
            var stream = new MemoryStream();
            Formatter.Serialize(stream, obj);
            return stream;
        }


        public Stream SerializeToStream<T>(T obj, int bufferSize = 1024) where T : class
        {
           return  SerializeToStream(obj, typeof(T), bufferSize);
        }



        public string SerializeToString(object obj)
        {
            var memoryStream = new MemoryStream();
            using (memoryStream)
            {
                Formatter.Serialize(memoryStream, obj);
                var base64String = Convert.ToBase64String(memoryStream.ToArray());
                return base64String;
            }
        }

        public string SerializeToString<T>(T obj) where T : class
        {
            var memoryStream = new MemoryStream();
            using (memoryStream)
            {
                Formatter.Serialize(memoryStream, obj);
                var base64String = Convert.ToBase64String(memoryStream.ToArray());
                return base64String;
            }
        }

        public List<dynamic> DeserializeToList(string content)
        {
            using (var memoryStream = content.FromBase64StringToStream(Encoding))
            {
                return (List<dynamic>)Formatter.Deserialize(memoryStream);
            }      
        }

        public List<dynamic> DeserializeToList(Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false)
        {
            return (List<dynamic>)Formatter.Deserialize(stream);
        }

        public List<T> DeserializeToList<T>(string content) where T : class
        {
            using (var memoryStream = content.FromBase64StringToStream(Encoding))
            {
                return (List<T>)Formatter.Deserialize(memoryStream);
            }
        }

        public List<T> DeserializeToList<T>(Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false) where T : class
        {
            return (List<T>)Formatter.Deserialize(stream);
        }

        public List<object> DeserializeToList(string content, Type type)
        {
            using (var memoryStream = content.FromBase64StringToStream(Encoding))
            {
                return (List<object>)Formatter.Deserialize(memoryStream);
            }
        }

        public List<object> DeserializeToList(Stream stream, Type type, int bufferSize = 1024, bool leaveStreamOpen = false)
        {
            return (List<object>)Formatter.Deserialize(stream);
        }

        public dynamic Deserialize(string content)
        {
            using (var memoryStream = content.FromBase64StringToStream(Encoding))
            {
                return Formatter.Deserialize(memoryStream);
            }
        }

        public dynamic Deserialize(Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false)
        {
            return (List<object>)Formatter.Deserialize(stream);
        }

        public T Deserialize<T>(string content) where T : class
        {
            return (T) Deserialize(content, typeof(T));
        }

        public T Deserialize<T>(Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false) where T : class
        {
            return (T)Formatter.Deserialize(stream);
        }

        public object Deserialize(string content, Type type)
        {
            using (var stream = content.FromBase64StringToStream(Encoding))
            {
                return Formatter.Deserialize(stream);
            }
        }

        public object Deserialize(Stream stream, Type type, int bufferSize = 1024, bool leaveStreamOpen = false)
        {
            return Formatter.Deserialize(stream);
        }


    }
}
