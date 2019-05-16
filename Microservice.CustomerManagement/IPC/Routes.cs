using Microservice.Common.Logging;
using Microservice.CustomerManagement.Service;
using Microsoft.Extensions.Configuration;
using Nancy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.CustomerManagement.IPC
{
    public class Routes : NancyModule
    {
        public Routes(ICustomerService servcie, ILog logger) : base("/customers")
        {
			logger.Debug($"Setting up routes to use service {servcie}");

            Get("/", _ => "Hallo!");
        }

    }
}
