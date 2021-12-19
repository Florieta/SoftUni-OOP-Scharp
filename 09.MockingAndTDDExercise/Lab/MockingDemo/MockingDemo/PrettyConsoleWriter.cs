using System;

namespace MockingDemo
{
    public class PrettyConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(new string('-', 60));
            Console.WriteLine('-' + text + new string(' ', 60 - 2 - text.Length) + '-');
            Console.WriteLine(new string('-', 60));
        }
    }
}
