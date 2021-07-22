using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core.Models
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter command)
        {
            this.commandInterpreter = command;
        }

        public void Run()
        {
            while (true)
            {
                string inputLine = Console.ReadLine();
                string executionResult = commandInterpreter.Read(inputLine);
                
                if (executionResult == null)
                {
                    break;
                }

                Console.WriteLine(executionResult);
            }
        }
    }
}
