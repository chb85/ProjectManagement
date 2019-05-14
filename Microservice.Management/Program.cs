using Microservice.CustomerManagement.Service;
using System;
using System.Configuration;

namespace Microservice.Management
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = 0;

            NLog.LogManager.Configuration = new NLog.Config
                .XmlLoggingConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location + ".config");
            var log = NLog.LogManager.GetLogger("TestLogger", typeof(Program));

            var config = NLog.LogManager.Configuration;

            log.Debug("Application started.");

            // Setup service container
            //var customerService = new CustomerService();
            

            // Configure all services and run in extra class/interface.
        }
    }
}
