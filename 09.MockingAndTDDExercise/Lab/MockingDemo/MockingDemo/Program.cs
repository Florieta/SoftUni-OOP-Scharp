using System;

namespace MockingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = new GreetingWriter(new MessageBoxWriter());
            writer.WriteGreeting(DateTime.Now);
        }
    }
}
