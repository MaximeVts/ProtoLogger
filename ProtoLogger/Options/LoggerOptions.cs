using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoLogger.Options
{
    public class LoggerOptions
    {
        /// <summary>
        /// Target of the logger
        /// </summary>
        public LoggerTarget Target { get; set; }
        /// <summary>
        /// Format for the date that will be applied, follow the standard patterns for the current culture
        /// </summary>
        public string DateFormat { get; set; }
        /// <summary>
        /// Used when using targeting a file, the location of the log file
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// Connection string when logging to a SQL Server database
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
