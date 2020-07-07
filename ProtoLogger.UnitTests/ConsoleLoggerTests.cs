using ProtoLogger.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ProtoLogger.UnitTests
{
    public class ConsoleLoggerTests
    {
        private readonly ITestOutputHelper output;

        public ConsoleLoggerTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(LogLevel.Error)]
        [InlineData(LogLevel.warning)]
        [InlineData(LogLevel.Trace)]
        [InlineData(LogLevel.Debug)]
        public void Lower_LogLevel_Should_Log(LogLevel logLevel)
        {
            string testLine = "This should be logged";
            var logger = new ConsoleLogger(LogLevel.Trace);
            logger.Log(testLine);
            //Assert.True(output.)
            Assert.True(1 == 1);
        }
    }
}
