using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNetHelper.Serialization.Abstractions.Extension
{
    internal static class ObjectExtension
    {
        public static void IsNullThrow(this object obj, string name, Exception error = null)
        {
            if (obj != null) return;
            if (error == null) error = new ArgumentNullException(name);
            throw error;
        }


        /// <summary>
        /// Obtains the data as a list; if it is *already* a list, the original object is returned without
        /// any duplication; otherwise, ToList() is invoked.
        /// </summary>
        /// <typeparam name="T">The type of element in the list.</typeparam>
        /// <param name="source">The enumerable to return as a list.</param>
        public static List<T> AsList<T>(this IEnumerable<T> source) => (source == null || source is List<T>) ? (List<T>)source : source.ToList();


        public static bool IsStringBase64Encoded(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return Regex.IsMatch(s, "^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)?$"); // https://stackoverflow.com/questions/8571501/how-to-check-whether-a-string-is-base64-encoded-or-not
        }
        public static Stream FromBase64StringToStream(this string s, Encoding encoding)
        {
            if (s.IsStringBase64Encoded())
            {
                var bytes = Convert.FromBase64String(s);
                return new MemoryStream(bytes);
            }
            else
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
}
