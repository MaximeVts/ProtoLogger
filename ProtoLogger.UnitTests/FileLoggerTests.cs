using ProtoLogger.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ProtoLogger.UnitTests
{

    public class FileLoggerTests
    {
        private readonly string _filePath = @".\test.log";

        private void HandleFile()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }

        [Fact]
        public void Log_Should_Create_File()
        {
            string testLine = "This is a log";
            HandleFile();
            var logger = new FileLogger(_filePath, LogLevel.Error);
            logger.Log(testLine, LogLevel.Error);
            Assert.True(File.Exists(_filePath));
        }

        [Fact]
        public void Log_Exception_Logged()
        {
            var testException = new Exception("This is an exception");
            HandleFile();
            var logger = new FileLogger(_filePath, LogLevel.Error);
            logger.Log(testException);
            Assert.True(File.Exists(_filePath));
        }
    }
}
