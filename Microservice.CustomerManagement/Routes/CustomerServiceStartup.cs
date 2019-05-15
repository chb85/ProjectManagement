using Microservice.Common;
using Microservice.Common.Configuration;
using Microservice.Common.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Nancy;
using Nancy.Owin;

namespace Microservice.CustomerManagement.Routes
{
    public class CustomerServiceStartup
	{
		public void Configure(
            IApplicationBuilder app, 
            ServiceConfiguration configuration, 
            ILog log)
		{
            app.UseOwin(x => x.UseNancy(opt => opt.Bootstrapper = new Bootstrapper(configuration, log)));
		}
	}
}
