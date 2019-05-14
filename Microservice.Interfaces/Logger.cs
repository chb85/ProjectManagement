using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.Interfaces
{
    public class Logger : ILog
    {
        public ILog Configure(string configurationFile)
        {
            LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(configurationFile);
            return this;
        }

        public void Debug<TYPE>(string message)
        {
            LogManager.GetLogger(typeof(TYPE).FullName).Debug(message);
        }

        public void Info<TYPE>(string message)
        {
            LogManager.GetLogger(typeof(TYPE).FullName).Info(message);
        }

        public void Error<TYPE>(string message)
        {
            LogManager.GetLogger(typeof(TYPE).FullName).Error(message);
        }

        public void Fatal<TYPE>(string message)
        {
            LogManager.GetLogger(typeof(TYPE).FullName).Fatal(message);
        }
    }
}
