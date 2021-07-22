using System;
using System.Reflection;


namespace CommandPattern.Core.Models
{
    using Contracts;
    using System.Linq;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = tokens[0];
            string[] arguments = tokens
                .Skip(1)
                .ToArray();

            Type commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(m => m.Name == $"{commandName}Command");

            ICommand instance = (ICommand)Activator.CreateInstance(commandType);
            string executionResult = instance.Execute(arguments);

            return executionResult;
        }
    }
}
