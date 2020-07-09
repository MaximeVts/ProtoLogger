using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqliteDb
{
    public sealed class DbRepository
    {
        private readonly LoggerContext _loggerContext;

        public DbRepository(string connectionString)
        {
            _loggerContext = new LoggerContext(connectionString);
        }
        public void CommitToDatabaseAsync(string logEntry, DateTime timeOfEntry)
        {
            _loggerContext.Database.EnsureCreated();

            var log = new Log
            {
                CreatedDate = timeOfEntry,
                Message = logEntry
            };
            _loggerContext.Logs.Add(log);
            _loggerContext.SaveChanges();
        }
        public IEnumerable<Log> GetTopLogs()
        {
            return _loggerContext.Logs.Take(5).ToList();
        }
        public Log GetFirstLog()
        {
            return _loggerContext.Logs.FirstOrDefault();
        }
    }

    
}

