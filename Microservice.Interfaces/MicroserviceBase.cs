using System;
using System.IO;
using Microservice.Common.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Common
{
	public class MicroserviceBase<STARTUP_TYPE> where STARTUP_TYPE : class
	{
		private IWebHost mWebHost;

		private ILog mLog;

		public string BaseUrl { get; private set; }

		public MicroserviceBase(string baseUrl, ILog log)
		{
			BaseUrl = baseUrl;
			mLog = log;
		}

		public virtual void StartService()
		{
			try
			{
				SetupWebHost();
				mWebHost.Start();
			}
			catch (Exception e)
			{
				mLog.Error($"Error during web host start: {e.Message}");
				throw;
			}
		}

		protected virtual void SetupWebHost()
		{
			mWebHost = new WebHostBuilder()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseKestrel()
				.UseUrls(BaseUrl)
				.ConfigureServices(x => x.AddSingleton<ILog>(mLog))
				.UseStartup<STARTUP_TYPE>()
				.Build();
		}
	}
}
