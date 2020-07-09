using ProtoLogger.Enums;
using SqliteDb;
using System;

namespace ProtoLogger
{
    public class DatabaseLogger : BaseLogger
    {
        private readonly DbRepository _db;

        public DatabaseLogger(string connectionString, LogLevel appLogLevel = LogLevel.Error, string dateFormat = "")
            :base(appLogLevel, dateFormat)
        {
            _db = new DbRepository(connectionString);
        }
        public override void Log(string message, LogLevel logLevel = LogLevel.Error)
        {
            DateTime currentTime = DateTime.Now;            
            _db.CommitToDatabaseAsync(FormatLogs(message, currentTime), currentTime);
        }

        public override void Log(Exception exception)
        {
            DateTime currentTime = DateTime.Now;            
            _db.CommitToDatabaseAsync(FormatLogs(exception, currentTime), currentTime);
        }
    }
}
