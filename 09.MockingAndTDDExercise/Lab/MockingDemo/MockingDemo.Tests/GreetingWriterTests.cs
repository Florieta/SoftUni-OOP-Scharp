using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace MockingDemo.Tests
{
    [TestFixture]
    public class GreetingWriterTests
    {
        [Test]
        public void WriteGreetingShouldWorkCorrectlyInTheMorning()
        {
            string result = null;
            var myWriter = new Mock<IWriter>();
            myWriter.Setup(x => x.Write(It.IsAny<string>()))
                .Callback((string s) => result = s);
            var writer = new GreetingWriter(myWriter.Object);
            writer.WriteGreeting(new DateTime(2021, 1, 1, 8, 0, 0));
            Assert.True(result.ToLower().Contains("morning"));
        }

        [Test]
        public void WriteGreetingShouldWorkCorrectlyInTheEvening()
        {
            var memory = new MemoryWriter();
            var writer = new GreetingWriter(memory);
            writer.WriteGreeting(new DateTime(2021, 1, 1, 19, 0, 0));
            Assert.True(memory.ToString().ToLower().Contains("evening"));
        }

        [Test]
        public void WriteGreetingShouldWorkCorrectlyInTheAfternoob()
        {
            var memory = new MemoryWriter();
            var writer = new GreetingWriter(memory);
            writer.WriteGreeting(new DateTime(2021, 1, 1, 15, 0, 0));
            Assert.True(memory.ToString().ToLower().Contains("afternoon"));
        }

        class MemoryWriter : IWriter
        {
            private StringBuilder sb = new StringBuilder();

            public void Write(string text)
            {
                sb.AppendLine(text);
            }

            public override string ToString()
            {
                return sb.ToString();
            }
        }
    }
}
