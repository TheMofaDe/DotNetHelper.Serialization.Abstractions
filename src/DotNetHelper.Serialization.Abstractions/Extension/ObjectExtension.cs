using System;
using System.Collections.Generic;
using System.IO;
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
