using Microsoft.Extensions.Logging;


namespace UTAF.Core.Logger
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogger<LoggerService> logger;

        public LoggerService(ILogger<LoggerService> logger)
        {
            this.logger = logger;
        }

        public void LogInformation(string message)
        {
            logger.LogInformation(message);
        }

        public void LogError(string message)
        {
            logger.LogError(message);
        }




    }
}
