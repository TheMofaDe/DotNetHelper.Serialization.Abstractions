using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using DotNetHelper.Serialization.Abstractions.Tests.Models;

namespace DotNetHelper.Serialization.Abstractions.Tests
{
    public static class MockData
    {

        public static Employee Employee { get; } = new Employee();

        public static string EmployeeAsBinaryString { get; } = "AAEAAAD/////AQAAAAAAAAAMAgAAAGREb3ROZXRIZWxwZXIuU2VyaWFsaXphdGlvbi5BYnN0cmFjdGlvbnMuVGVzdHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsBQEAAAA9RG90TmV0SGVscGVyLlNlcmlhbGl6YXRpb24uQWJzdHJhY3Rpb25zLlRlc3RzLk1vZGVscy5FbXBsb3llZQIAAAAaPEZpcnN0TmFtZT5rX19CYWNraW5nRmllbGQZPExhc3ROYW1lPmtfX0JhY2tpbmdGaWVsZAEBAgAAAAYDAAAABEthdGUGBAAAAAVCbGFrZQs=";

        public static List<Employee> EmployeeList { get; } = new List<Employee>() { Employee
            , new Employee(){FirstName = "Mabelle",LastName = "Black" } };
        public static string EmployeeAsBinaryStringList { get; } = @"AAEAAAD/////AQAAAAAAAAAMAgAAAGREb3ROZXRIZWxwZXIuU2VyaWFsaXphdGlvbi5BYnN0cmFjdGlvbnMuVGVzdHMsIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsBAEAAADIAVN5c3RlbS5Db2xsZWN0aW9ucy5HZW5lcmljLkxpc3RgMVtbRG90TmV0SGVscGVyLlNlcmlhbGl6YXRpb24uQWJzdHJhY3Rpb25zLlRlc3RzLk1vZGVscy5FbXBsb3llZSwgRG90TmV0SGVscGVyLlNlcmlhbGl6YXRpb24uQWJzdHJhY3Rpb25zLlRlc3RzLCBWZXJzaW9uPTEuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49bnVsbF1dAwAAAAZfaXRlbXMFX3NpemUIX3ZlcnNpb24EAAA/RG90TmV0SGVscGVyLlNlcmlhbGl6YXRpb24uQWJzdHJhY3Rpb25zLlRlc3RzLk1vZGVscy5FbXBsb3llZVtdAgAAAAgICQMAAAACAAAAAgAAAAcDAAAAAAEAAAAEAAAABD1Eb3ROZXRIZWxwZXIuU2VyaWFsaXphdGlvbi5BYnN0cmFjdGlvbnMuVGVzdHMuTW9kZWxzLkVtcGxveWVlAgAAAAkEAAAACQUAAAANAgUEAAAAPURvdE5ldEhlbHBlci5TZXJpYWxpemF0aW9uLkFic3RyYWN0aW9ucy5UZXN0cy5Nb2RlbHMuRW1wbG95ZWUCAAAAGjxGaXJzdE5hbWU+a19fQmFja2luZ0ZpZWxkGTxMYXN0TmFtZT5rX19CYWNraW5nRmllbGQBAQIAAAAGBgAAAARLYXRlBgcAAAAFQmxha2UBBQAAAAQAAAAGCAAAAAdNYWJlbGxlBgkAAAAFQmxhY2sL";

        public static Stream GetEmployeeAsStream(Encoding encoding)
        {
            return EmployeeAsBinaryString.FromBase64StringToStream(Encoding.UTF8);
        }
        public static Stream GetEmployeeListAsStream(Encoding encoding)
        {
            return EmployeeAsBinaryStringList.FromBase64StringToStream(Encoding.UTF8);  // new MemoryStream(encoding.GetBytes(EmployeeAsCsvWithHeaderList));
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
