using System;
using System.Collections.Generic;
using System.IO;

namespace DotNetHelper.Serialization.Abstractions.Interface
{
    public interface ISerializer 
    {
        /// <summary>
        /// Serializes the generic object to a new instance of a memory stream.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="stream">The stream.</param>
        /// <param name="bufferSize"></param>
        /// <param name="leaveStreamOpen"></param>
        /// <exception cref="System.ArgumentNullException">obj</exception>
        void SerializeToStream<T>(T obj, Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false) where T : class;

        ///// <summary>
        ///// Serializes the list to stream.
        ///// </summary>
        ///// <param name="objects">The objects.</param>
        ///// <param name="stream">The stream.</param>
        ///// <param name="bufferSize"></param>
        ///// <param name="leaveStreamOpen"></param>
        ///// <exception cref="System.ArgumentNullException">obj</exception>
        //void SerializeListToStream<T>(IEnumerable<T> objects, Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false) where T : class;


        /// <summary>
        /// Serializes the object to the provided stream.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="type"></param>
        /// <param name="stream">The stream.</param>
        /// <param name="bufferSize"></param>
        /// <param name="leaveStreamOpen"></param>
        /// <exception cref="System.ArgumentNullException">obj</exception>
        void SerializeToStream(object obj, Type type, Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false);

        /// <summary>
        /// Serializes the generic object to a new instance of a memory stream.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="bufferSize"></param>
        /// <exception cref="System.ArgumentNullException">obj</exception>
        Stream SerializeToStream<T>(T obj, int bufferSize = 1024) where T : class;

        ///// <summary>
        ///// Serializes the list to stream.
        ///// </summary>
        ///// <param name="objects">The object.</param>
        ///// <param name="bufferSize"></param>
        ///// <exception cref="System.ArgumentNullException">obj</exception>
        //Stream SerializeListToStream<T>(IEnumerable<T> objects, int bufferSize = 1024) where T : class;


        /// <summary>
        /// Serializes the object to a new instance of a memory stream.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="type"></param>
        /// <param name="bufferSize"></param>
        /// <exception cref="System.ArgumentNullException">obj</exception>
        Stream SerializeToStream(object obj, Type type,  int bufferSize = 1024);

        /// <summary>
        /// Serializes to string.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ArgumentNullException">obj</exception>
        string SerializeToString(object obj);

        /// <summary>
        /// Serializes to string.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ArgumentNullException">obj</exception>
        string SerializeToString<T>(T obj) where T : class;

        ///// <summary>
        ///// Serializes the list to string.
        ///// </summary>
        ///// <param name="obj">The obj.</param>
        ///// <returns>System.String.</returns>
        ///// <exception cref="System.ArgumentNullException">obj</exception>
        //string SerializeListToString<T>(IEnumerable<T> obj) where T : class;

        /// <summary>
        /// Deserializes from a string to a list of dynamic objects 
        /// </summary>
        /// <param name="content">A delimited CSV string.</param>
        /// <returns>IEnumerable&lt;dynamic&gt;.</returns>
        List<dynamic> DeserializeToList(string content);

        /// <summary>
        /// Deserializes from a string to a list of dynamic objects 
        /// </summary>
        /// <param name="stream">A delimited CSV string.</param>
        /// <param name="bufferSize"></param>
        /// <param name="leaveStreamOpen"></param>
        /// <returns>IEnumerable&lt;dynamic&gt;.</returns>
        List<dynamic> DeserializeToList(Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false);


        /// <summary>
        /// Deserializes from string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns>List Of T</returns>
        /// <exception cref="System.ArgumentNullException">text</exception>
        List<T> DeserializeToList<T>(string content) where T : class;

        /// <summary>
        /// Deserializes from string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <param name="bufferSize"></param>
        /// <param name="leaveStreamOpen"></param>
        /// <returns>List Of T</returns>
        /// <exception cref="System.ArgumentNullException">text</exception>
        List<T> DeserializeToList<T>(Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false) where T : class;


        /// <summary>
        /// Deserializes from string.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="System.ArgumentNullException">json</exception>
        List<object> DeserializeToList(string content, Type type);



        /// <summary>
        /// Deserializes from a string to a list of dynamic objects 
        /// </summary>
        /// <param name="content"></param>
        /// <returns>IEnumerable&lt;dynamic&gt;.</returns>
        dynamic Deserialize(string content);

        /// <summary>
        /// Deserializes from a string to a list of dynamic objects 
        /// </summary>
        /// <param name="stream">A stream.</param>
        /// <param name="bufferSize"></param>
        /// <param name="leaveStreamOpen"></param>
        /// <returns>IEnumerable&lt;dynamic&gt;.</returns>
        dynamic Deserialize(Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false);


        /// <summary>
        /// Deserializes from string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns>List Of T</returns>
        /// <exception cref="System.ArgumentNullException">text</exception>
        T Deserialize<T>(string content) where T : class;

        /// <summary>
        /// Deserializes from string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <param name="bufferSize"></param>
        /// <param name="leaveStreamOpen"></param>
        /// <returns>List Of T</returns>
        /// <exception cref="System.ArgumentNullException">text</exception>
        T Deserialize<T>(Stream stream, int bufferSize = 1024, bool leaveStreamOpen = false) where T : class;


        /// <summary>
        /// Deserializes from string.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="System.ArgumentNullException">json</exception>
        object Deserialize(string content, Type type);

        /// <summary>
        /// Deserializes from string.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type">The type.</param>
        /// <param name="bufferSize"></param>
        /// <param name="leaveStreamOpen"></param>
        /// <returns>System.Object.</returns>
        /// <exception cref="System.ArgumentNullException">json</exception>
        object Deserialize(Stream stream, Type type, int bufferSize = 1024, bool leaveStreamOpen = false);

    }
}
