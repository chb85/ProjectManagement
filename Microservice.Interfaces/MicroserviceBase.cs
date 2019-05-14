using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Microservice.Interfaces
{
    public abstract class MicroserviceBase
    {
        private IWebHost mWebHost;

        private readonly ILog mLog;

        public MicroserviceBase(IConfiguration configuration, ILog log)
        {
            mLog = log;
            Configure(configuration);
        }

        public void StartService()
        {
            const string ERROR_MESSAGE = "Service can not be started, no host was provided.";
            if (mWebHost == null)
            {
                mLog.Fatal(ERROR_MESSAGE);
                throw new ApplicationException(ERROR_MESSAGE);
            }

            mWebHost.Start();
        }

        private void Configure(IConfiguration config)
        {
            mWebHost = new WebHostBuilder()
               // TODO is tjis nessacery? .UseContentRoot(Directory.GetCurrentDirectory())
               .UseKestrel()
               // TODO get Startup from config .UseStartup("")
               .Build();
            // TODO use right config section .UseUrls(config.GetSection("AppSettings").GetValue<string>("BaseUrl.CustomerService"))

        }
    }
}
