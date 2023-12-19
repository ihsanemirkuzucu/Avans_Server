using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Log.Methods;
using NLog;

namespace AvansProjeServer.Log.Service
{
    public class LoggerService : ILoggerManager
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public LoggerService()
        {
                
        }

        public void LogInfo(string message) => _logger.Info(message);


        public void LogWarning(string message) => _logger.Warn(message);


        public void LogError(string message) => _logger.Error(message);

    }
}
