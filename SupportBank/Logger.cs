using System;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank
{
    public class Logger
    {
        private readonly ILogger logger;
        private static readonly string fileName = @"C:\Work\Training\SupportBank\Logs\SupportBank.log";

        public Logger(ILogger passedInLogger)
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget
            {
                FileName = fileName,
                Layout = @"${longdate} ${level} - ${logger}: ${message}"
            };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;
            logger = passedInLogger;
        }

        public void LogError(Exception error)
        {
            logger.Error(error, error.ToString());
            //throw error;
        }
    }
}