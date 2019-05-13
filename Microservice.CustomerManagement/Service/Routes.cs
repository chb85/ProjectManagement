using Microsoft.Extensions.Configuration;
using Nancy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.CustomerManagement.Service
{
    public class Routes : NancyModule
    {
        public Routes(IConfiguration config) : base("/customers")
        {
            Get("/", _ => "Hallo!");
        }

    }
}
