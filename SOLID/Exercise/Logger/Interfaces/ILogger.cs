using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerLibrary.Interfaces
{
    public interface ILogger
    {
        public void Info(string data, string message);
        public void Warning(string data, string message);
        public void Error(string data, string message);
        public void Critical(string data, string message);
        public void Fatal(string data, string message);
    }
}
