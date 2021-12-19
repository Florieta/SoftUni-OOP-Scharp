using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingDemo
{
    public class GreetingWriter
    {
        private readonly IWriter writer;

        public GreetingWriter()
            : this(new ConsoleWriter())
        {
        }

        public GreetingWriter(IWriter writer)
        {
            this.writer = writer;
        }

        public void WriteGreeting()
        {
            WriteGreeting(DateTime.Now);
        }

        public void WriteGreeting(DateTime dateTime)
        {
            if (dateTime.Hour < 12)
            {
                writer.Write("Good morning!");
            }
            else if (dateTime.Hour < 17)
            {
                writer.Write("Good afternoon!");
            }
            else
            {
                writer.Write("Good evening!");
            }
        }
    }
}
