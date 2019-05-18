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
            if (leaveStreamOpen)
            {
                stream.Seek(0, SeekOrigin.Begin);
            }
            else
            {
                stream.Dispose();
            }
        }

        public Stream SerializeToStream(object obj, Type type, int bufferSize = 1024)
        {
            obj.IsNullThrow(nameof(obj));
            var stream = new MemoryStream();
            using (stream)
            {
                Formatter.Serialize(stream, obj);
            }
            return stream;
        }


        public Stream SerializeToStream<T>(T obj, int bufferSize = 1024) where T : class
        {
           return  SerializeToStream(obj, typeof(T), bufferSize);
        }



        public string SerializeToString(object obj)
        {
            using (var stream = SerializeToStream(obj, obj.GetType()))
            {
               var sr = new StreamReader(stream, Encoding, true, 1024, false);
                return sr.ReadToEnd();
            }
        }

        public string SerializeToString<T>(T obj) where T : class
        {
            using (var stream = SerializeToStream(obj, obj.GetType()))
            {
                var sr = new StreamReader(stream, Encoding, true, 1024, false);
                return sr.ReadToEnd();
            }
        }

        public List<dynamic> DeserializeToList(string content)
        {
            var bytes = Encoding.GetBytes(content);
            using (var memoryStream = new MemoryStream(bytes))
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
            var bytes = Encoding.GetBytes(content);
            using (var memoryStream = new MemoryStream(bytes))
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
            var bytes = Encoding.GetBytes(content);
            using (var memoryStream = new MemoryStream(bytes))
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
            var bytes = Encoding.GetBytes(content);
            using (var memoryStream = new MemoryStream(bytes))
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
            var bytes = Encoding.GetBytes(content);
            using (var memoryStream = new MemoryStream(bytes))
            {
                return (T)Formatter.Deserialize(memoryStream);
            }
        }

        public T Deserialize<T>(Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false) where T : class
        {
            return (T)Formatter.Deserialize(stream);
        }

        public object Deserialize(string content, Type type)
        {
            var bytes = Encoding.GetBytes(content);
            using (var memoryStream = new MemoryStream(bytes))
            {
                return Formatter.Deserialize(memoryStream);
            }
        }

        public object Deserialize(Stream stream, Type type, int bufferSize = 1024, bool leaveStreamOpen = false)
        {
            return Formatter.Deserialize(stream);
        }


        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
