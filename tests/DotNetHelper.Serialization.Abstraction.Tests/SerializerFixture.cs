using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using DotNetHelper.Serialization.Abstractions;
using DotNetHelper.Serialization.Abstractions.Tests;
using DotNetHelper.Serialization.Abstractions.Tests.Models;

using NUnit.Framework;

namespace DotNetHelper.Serialization.Binary.Tests
{
    [TestFixture]
    [NonParallelizable] //since were sharing a single file across multiple test cases we don't want Parallelizable
    public class BinarySerializerTextFixture
    {


        public DataSourceBinary DataSource { get; set; } = new DataSourceBinary();

        public BinarySerializerTextFixture()
        {

        }


        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            DataSource = new DataSourceBinary(Encoding.UTF8);
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {

        }



        [SetUp]
        public void Init()
        {

        }

        [TearDown]
        public void Cleanup()
        {

        }

        [Author("Joseph McNeal Jr", "josephmcnealjr@gmail.com")]
        [Test]
        public void Test_Serialize_Generic_To_Binary()
        {
            var Binary = DataSource.SerializeToString(MockData.Employee);
            EnsureGenericObjectMatchMockDataBinary(Binary);
        }
        [Author("Joseph McNeal Jr", "josephmcnealjr@gmail.com")]
        [Test]
        public void Test_Serialize_Object_To_Binary()
        {
            var Binary = DataSource.SerializeToString((object)MockData.Employee);
            EnsureGenericObjectMatchMockDataBinary(Binary);
        }
        [Author("Joseph McNeal Jr", "josephmcnealjr@gmail.com")]
        [Test]
        public void Test_Serialize_Generic_To_My_Stream_And_Stream_Wont_Dispose()
        {
            var stream = new MemoryStream();
            DataSource.SerializeToStream(MockData.Employee, stream, 1024, true);
            EnsureStreamMatchMockDataBinary(stream);
            EnsureStreamIsNotDisposeAndIsAtEndOfStream(stream);
            stream.Seek(0, SeekOrigin.Begin);
        }



        [Author("Joseph McNeal Jr", "josephmcnealjr@gmail.com")]
        [Test]
        public void Test_Serialize_Generic_To_My_Stream_And_Stream_Is_Dispose()
        {
            var stream = new MemoryStream();
            DataSource.SerializeToStream(MockData.Employee, stream, 1024, false);
            EnsureStreamIsDispose(stream);
        }

        [Author("Joseph McNeal Jr", "josephmcnealjr@gmail.com")]
        [Test]
        public void Test_Serialize_Object_To_My_Stream_And_Stream_Wont_Dispose()
        {
            var stream = new MemoryStream();
            DataSource.SerializeToStream(MockData.Employee, typeof(Employee), stream, 1024, true);
            EnsureStreamMatchMockDataBinary(stream);
            EnsureStreamIsNotDisposeAndIsAtEndOfStream(stream);
            stream.Seek(0, SeekOrigin.Begin);
        }
        [Author("Joseph McNeal Jr", "josephmcnealjr@gmail.com")]
        [Test]
        public void Test_Serialize_Object_To_My_Stream_And_Stream_Is_Dispose()
        {
            var stream = new MemoryStream();
            DataSource.SerializeToStream(MockData.Employee, typeof(Employee), stream, 1024, false);
            EnsureStreamIsDispose(stream);
        }




        [Author("Joseph McNeal Jr", "josephmcnealjr@gmail.com")]
        [Test]
        public void Test_Serialize_Generic_To_Stream_And_Stream_Wont_Dispose()
        {

            var stream = Stream.Synchronized(DataSource.SerializeToStream(MockData.Employee, 1024));
            EnsureStreamMatchMockDataBinary(stream);
            EnsureStreamIsNotDisposeAndIsAtEndOfStream(stream);
            stream.Seek(0, SeekOrigin.Begin);
        }


        [Author("Joseph McNeal Jr", "josephmcnealjr@gmail.com")]
        [Test]
        public void Test_Serialize_Generic_List_To_Stream_And_Stream_Wont_Dispose()
        {

            var stream = Stream.Synchronized(DataSource.SerializeToStream(MockData.EmployeeList, 1024));
            var stream3 = MockData.GetEmployeeListAsStream(DataSource.Encoding);
            var stream43 = MockData.GetEmployeeListAsStream(Encoding.ASCII);
            EnsureStreamMatchMockDataBinary(stream);
            EnsureStreamIsNotDisposeAndIsAtEndOfStream(stream);
            stream.Seek(0, SeekOrigin.Begin);
        }


        [Author("Joseph McNeal Jr", "josephmcnealjr@gmail.com")]
        [Test]
        public void Test_Serialize_Generic_To_Stream_And_Stream_Is_Dispose()
        {

            var stream = DataSource.SerializeToStream(MockData.Employee, 1024);
            EnsureStreamMatchMockDataBinary(stream);
            EnsureStreamIsNotDisposeAndIsAtEndOfStream(stream);
        }



        [Author("Joseph McNeal Jr", "josephmcnealjr@gmail.com")]
        [Test]
        public void Test_Serialize_Object_To_Stream_And_Stream_Wont_Dispose()
        {

            var stream = Stream.Synchronized(DataSource.SerializeToStream(MockData.Employee, MockData.Employee.GetType(), 1024));
            EnsureStreamMatchMockDataBinary(stream);
            EnsureStreamIsNotDisposeAndIsAtEndOfStream(stream);
            stream.Seek(0, SeekOrigin.Begin);
        }
        [Author("Joseph McNeal Jr", "josephmcnealjr@gmail.com")]
        [Test]
        public void Test_Serialize_Object_To_Stream_And_Stream_Is_Dispose()
        {

            var stream = DataSource.SerializeToStream(MockData.Employee, MockData.Employee.GetType(), 1024);
            EnsureStreamMatchMockDataBinary(stream);
            EnsureStreamIsNotDisposeAndIsAtEndOfStream(stream);
        }





        private void EnsureGenericObjectMatchMockDataBinary(string Binary)
        {
            var equals = string.Equals(Binary, MockData.EmployeeAsBinaryString, StringComparison.OrdinalIgnoreCase);
            Assert.IsTrue(equals, $"Test failed due to Binary not matching mock data Binary");
        }

        private void EnsureStreamIsNotDisposeAndIsAtEndOfStream(Stream stream)
        {
            try
            {
                if (stream.Position != stream.Length)
                {
                    Assert.Fail("The entire stream has not been read");
                }
            }
            catch (ObjectDisposedException disposedException)
            {
                Assert.Fail($"The stream has been disposed {disposedException.Message}");
            }

        }


        private void EnsureStreamIsDispose(Stream stream)
        {
            try
            {
                var position = stream.Position;
                Assert.Fail("The stream is not disposed.");
            }
            catch (ObjectDisposedException)
            {
                return;
            }
        }


        private void EnsureStreamMatchMockDataBinary(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var listsStream = MockData.GetEmployeeListAsStream(DataSource.Encoding);
            var mockStream = stream.Length >= listsStream.Length ? listsStream : MockData.GetEmployeeAsStream(DataSource.Encoding);
            Assert.IsTrue(CompareStreams(stream, mockStream), "Stream doesn't match");
        }


        private bool CompareStreams(Stream a, Stream b)
        {
            if (a == null &&
                b == null)
                return true;
            if (a == null ||
                b == null)
            {
                throw new ArgumentNullException(
                    a == null ? "a" : "b");
            }

            var c = new StreamReader(a, DataSource.Encoding).ReadToEnd();
            var d = new StreamReader(b, DataSource.Encoding).ReadToEnd();
            return c.Equals(d, StringComparison.CurrentCulture);
            //if (a.Length < b.Length)
            //    return false;
            //if (a.Length > b.Length)
            //    return false;

            //for (int i = 0; i < b.Length; i++)
            //{
            //    int aByte = a.ReadByte();
            //    int bByte = b.ReadByte();
            //    if (aByte.CompareTo(bByte) != 0)
            //        return false;
            //}

            return true;
        }
    }
}