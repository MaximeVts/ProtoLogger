using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProtoLogger
{
    public class FileLogger : BaseLogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }
        public override void Log(string message)
        {
            WriteToFile(message);
        }

        public override void Log(Exception exception)
        {
            var formattedException = FormatException(exception.Message, exception.StackTrace);
            WriteToFile(formattedException);
        }

        private void WriteToFile(string message)
        {
            using StreamWriter streamWriter = new StreamWriter(_filePath);
            streamWriter.WriteLine(message);
            streamWriter.Close();
        }
    }
}
