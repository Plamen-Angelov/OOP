using LoggerLibrary.Interfaces;
using LoggerLibrary.Enumerators;
using LoggerLibrary.Appenders;
using System;

namespace LoggerLibrary.Loggers
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Error(string data, string message)
        {
            AppendMessage(data, ReportLevelEnum.Error, message);
        }

        public void Warning(string data, string message)
        {
            AppendMessage(data, ReportLevelEnum.Warning, message);
        }

        public void Info(string data, string message)
        {
            AppendMessage(data, ReportLevelEnum.Info, message);
        }

        public void Critical(string data, string message)
        {
            AppendMessage(data, ReportLevelEnum.Critical, message);
        }

        public void Fatal(string data, string message)
        {
            AppendMessage(data, ReportLevelEnum.Fatal, message);
        }

        public void AppendMessage(string data, ReportLevelEnum reportLevel, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(data, reportLevel, message);
            }
        }
    }
}
