using Microservice.Common.Logging;
using Microsoft.Extensions.Configuration;
using Nancy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.CustomerManagement.Service
{
    public class Routes : NancyModule
    {
        public Routes(ILog logger) : base("/customers")
        {
			logger.Debug("Setting up routes.");

            Get("/", _ => "Hallo!");
        }

    }
}
