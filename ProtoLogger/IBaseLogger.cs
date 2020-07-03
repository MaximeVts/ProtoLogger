using System;

namespace ProtoLogger
{
    public interface IBaseLogger
    {
        void Log(Exception exception);
        void Log(string message);
    }
}