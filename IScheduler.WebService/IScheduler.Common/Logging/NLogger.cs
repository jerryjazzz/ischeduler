using NLog;

namespace IScheduler.Common.Logging
{
    public class NLogger : ILogger
    {
        private readonly Logger _logger;

        public NLogger(string name)
        {
            this._logger = LogManager.GetLogger(name);
        }

        public string Name => this._logger.Name;

        public void LogTrace(string message)
        {
            this._logger.Trace(message);
        }

        public void LogDebug(string message)
        {
            this._logger.Debug(message);
        }

        public void LogInfo(string message)
        {
            this._logger.Info(message);
        }

        public void LogWarn(string message)
        {
            this._logger.Warn(message);
        }

        public void LogError(string message)
        {
            this._logger.Error(message);
        }

        public void LogFatal(string message)
        {
            this._logger.Fatal(message);
        }
    }
}