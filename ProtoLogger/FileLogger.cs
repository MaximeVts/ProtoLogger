using System;
using System.IO;

namespace ProtoLogger
{
    public class FileLogger : BaseLogger
    {
        private readonly string _filePath;        

        public FileLogger(string filePath, string dateFormat = "")
            :base(dateFormat)
        {
            _filePath = filePath;
        }
        public override void Log(string message)
        {           
            WriteToFile(FormatLogs(message, DateTime.Now));
        }

        public override void Log(Exception exception)
        {            
            WriteToFile(FormatLogs(exception, DateTime.Now));
        }

        private void WriteToFile(string message)
        {
            using StreamWriter streamWriter = new StreamWriter(_filePath);
            streamWriter.WriteLine(message);
            streamWriter.Close();
        }
    }
}
