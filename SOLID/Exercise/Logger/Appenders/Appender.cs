using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerLibrary.Appenders
{
    using LoggerLibrary.Enumerators;
    using LoggerLibrary.Interfaces;

    public abstract class Appender : IAppender
    {
        public ILayout Layout { get;  }

        public Appender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ReportLevelEnum ReportLevel { get; set; }

        protected string Content { get; private set; }

        public virtual void Append(string data, ReportLevelEnum reportLevel, string message)
        {
            if(reportLevel < ReportLevel)
            {
                return;
            }

            string content = string.Format(Layout.Template, data, reportLevel, message);
            Content = content;
        }
    }
}
