using Microservice.Common;
using Microservice.Common.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Nancy;
using Nancy.Owin;

namespace Microservice.CustomerManagement.Service
{
    public class CustomerServiceStartup
	{
		public void Configure(IHostingEnvironment enviorment, IApplicationBuilder app, ILog log)
		{
            app.UseOwin(x => x.UseNancy(opt => opt.Bootstrapper = new CommonBootstrapper(log)));
		}
	}
}
