using LoggerLibrary.Enumerators;
using LoggerLibrary.Interfaces;
using System;

namespace LoggerLibrary.Appenders
{
    class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {

        }

        public override void Append(string data, ReportLevelEnum reportLevel, string message)
        {
            base.Append(data, reportLevel, message);
            Console.WriteLine(Content);
        }
    }
}
