namespace IScheduler.Common.Logging
{
    public interface ILogger
    {
        string Name { get; }

        void LogTrace(string message);
        void LogDebug(string message);
        void LogInfo(string message);
        void LogWarn(string message);
        void LogError(string message);
        void LogFatal(string message);
    }
}