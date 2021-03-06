﻿using ProtoLogger.Enums;

namespace ProtoLogger.Options
{
    public class LoggerOptions
    {
        /// <summary>
        /// The minimum log level that will be used in the application
        /// </summary>
        public LogLevel ApplicationLogLevel{ get; set; }
        /// <summary>
        /// Target of the logger
        /// </summary>
        public LoggerTarget Target { get; set; }
        /// <summary>
        /// Format for the date that will be applied, follow the standard patterns for the current culture
        /// </summary>
        public string DateFormat { get; set; }
        /// <summary>
        /// Used when targeting a file, the location of the log file
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// Connection string when logging to a database
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
