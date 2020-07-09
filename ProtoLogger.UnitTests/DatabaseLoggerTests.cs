using SqliteDb;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace ProtoLogger.UnitTests
{
    public class DatabaseLoggerTests
    {
        private const string ConnectionString = "Data source=local.db";

        [Fact]
        public async Task Log_Appear_in_Db()
        {
            if (File.Exists("local.db"))
            {
                File.Delete("local.db");
            }
            string lineToLog = "Test Db logger";
            var dbLogger = new DatabaseLogger(ConnectionString, Enums.LogLevel.Error);
            dbLogger.Log(lineToLog);
            var db = new DbRepository(ConnectionString);
            var row = db.GetFirstLog();
            Assert.NotNull(row);
            Assert.Contains(lineToLog, row.Message);
        }
    }
}
