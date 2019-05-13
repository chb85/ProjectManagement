using Microservice.CustomerManagement.Configuration;
using Microservice.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace Microservice.CustomerManagement.Service
{
    public class CustomerService : IMicroservice
    {
        private IWebHost mWebHost;

        public void Configure(IConfiguration config)
        {
            mWebHost = new WebHostBuilder()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseKestrel()
               .UseStartup<Startup>()
               .UseUrls(config.GetSection("AppSettings").GetValue<string>("BaseUrl.CustomerService"))
               .Build();
        }

        public void StartService()
        {
            mWebHost.Run();
        }
    }
}
