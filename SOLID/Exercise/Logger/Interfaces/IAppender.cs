using LoggerLibrary.Enumerators;
using System;

namespace LoggerLibrary.Interfaces
{
    public interface IAppender
    {
        public void Append(string data, ReportLevelEnum reportLevel, string message);

        public ReportLevelEnum ReportLevel { get; set; }
    }
}
