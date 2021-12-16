using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandPattern.Core.Contracts;
using CommandPattern.Core.Models;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string input)
        {
            
            string[] tokens = input.Split();
            string commandName = tokens[0];
            string[] commandArgs = tokens[1..];

            //ICommand command = default;

            //if (commandName == "Hello")
            //{
            //    command = new HelloCommand();

            //}
            //else if (commandName == "Exit")
            //{
            //    command = new ExitCommand();

            //}
            Type commandType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == $"{commandName}Command");
            ICommand command = (ICommand)Activator.CreateInstance(commandType);
            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
