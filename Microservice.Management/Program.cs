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

            log.Debug<Program>("Application started.");
            log.Info<Program>("Application started.");
            log.Error<Program>("Application started.");
            log.Fatal<Program>("Application started.");

            // Setup service container
            //var customerService = new CustomerService();


            // Configure all services and run in extra class/interface.
        }
    }
}
