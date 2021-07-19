using System;
using System.IO;

namespace LoggerLibrary.Appenders
{
    using Interfaces;
    using LoggerLibrary.Enumerators;

    public class FileAppender : Appender
    {
        public ILogFile LogFile { get; set; }

        public FileAppender(ILayout layout, ILogFile file)
            :base(layout)
        {
            LogFile = file;
        }

        public override void Append(string data, ReportLevelEnum reportLevel, string message)
        {
            base.Append(data, reportLevel, message);
            LogFile.Write(Content);
        }
    }
}
