using ProtoLogger.Enums;
using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace ProtoLogger.UnitTests
{
    public class ConsoleLoggerTests
    {
        [Theory]
        [InlineData(LogLevel.Error)]
        [InlineData(LogLevel.warning)]
        [InlineData(LogLevel.Trace)]
        [InlineData(LogLevel.Debug)]
        public void Lower_LogLevel_Should_Log(LogLevel logLevel)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                string testLine = "This should be logged";
                //setup the app in debug mode so all logs should run
                var logger = new ConsoleLogger(LogLevel.Debug);
                logger.Log(testLine, logLevel);
                var result = sw.ToString();
                Assert.False(string.IsNullOrWhiteSpace(result));
            }
        }

        [Fact]
        public void Log_Message_NOT_Altered()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                string testLine = "This is a log";
                var logger = new ConsoleLogger(LogLevel.Error);
                logger.Log(testLine, LogLevel.Error);
                var result = sw.ToString();
                Assert.Contains(testLine, result);
            }
        }

        [Fact]
        public void Log_Exception_NOT_Altered()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var exception = new Exception("This is an exception");
                var logger = new ConsoleLogger(LogLevel.Error);
                logger.Log(exception);
                var result = sw.ToString();
                Assert.Contains(exception.Message, result);
            }
        }
    }
}
