using NLog;

namespace NulTien_XYZFashionAutomation.Utilities
{
    public static class LoggerManager
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public static void Info(string message) => logger.Info(message);
        public static void Warn(string message) => logger.Warn(message);
        public static void Error(string message) => logger.Error(message);
        public static void Debug(string message) => logger.Debug(message);
    }
}
