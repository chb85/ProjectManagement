using Microservice.CustomerManagement.Service;
using System;
using System.Configuration;

namespace Microservice.Management
{
    class Program
    {
        static void Main(string[] args)
        {

            // Setup service container
            var customerService = new CustomerService();
            

            // Configure all services and run in extra class/interface.
        }
    }
}
