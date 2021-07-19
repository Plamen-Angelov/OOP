using System;
using System.Linq;
using System.IO;

namespace LoggerLibrary.Loggers
{
    using Interfaces;
    public class LogFile : ILogFile
    {
        public int Size => File.ReadAllText("log.txt")
            .Where(x => char.IsLetter(x))
            .Sum(x => x);

        public void Write(string message)
        {
            File.AppendAllText("log.txt", message + Environment.NewLine);
        }
    }
}
