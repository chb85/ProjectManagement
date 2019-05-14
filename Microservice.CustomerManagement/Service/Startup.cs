using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nancy.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Microservice.CustomerManagement.Service
{
    public class Startup
    {
        private readonly IConfiguration mConfiguration;

        public Startup(IHostingEnvironment enviorment)
        {
			//var configBuilder = new ConfigurationBuilder()
			//    .SetBasePath(Directory.GetCurrentDirectory())
			//    .AddXmlFile("appconfig.xml");

			//mConfiguration = configBuilder.Build();
		}

        // TODO Configure container -> Logging, etc.

		public void Configure(IApplicationBuilder app)
		{
            app.UseOwin(x => x.UseNancy(opt => opt.Bootstrapper = new NancyBootstrapper(mConfiguration)));
		}
	}
}
