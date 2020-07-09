using Microsoft.EntityFrameworkCore;

namespace SqliteDb
{
    internal class LoggerContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite(_connectionString);

        public LoggerContext(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
        
    
}
