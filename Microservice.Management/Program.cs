using Microservice.CustomerManagement.Service;
using Microservice.Interfaces;
using System;
using System.Configuration;

namespace Microservice.Management
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new Logger()
                .Configure(System.Reflection.Assembly.GetExecutingAssembly().Location + ".config");

            log.Debug("Application started.");
            log.Info("Application started.");
            log.Error("Application started.");
            log.Fatal("Application started.");
            log.Trace("Application started.");

            Console.Read();
            // Setup service container
            //var customerService = new CustomerService();


            // Configure all services and run in extra class/interface.
        }
    }
}
