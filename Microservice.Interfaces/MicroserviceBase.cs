using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Microservice.Common
{
    public class MicroserviceBase<STARTUP_TYPE> where STARTUP_TYPE : class
	{
		private IWebHost mWebHost;

		public readonly ILog Log;

		public string BaseUrl { get; private set; }

		public MicroserviceBase(string baseUrl, ILog log)
        {
			Log = log;
			BaseUrl = baseUrl;
		}

        public virtual void StartService()
        {
			try
			{
				SetupWebHost();
				mWebHost.Start();
				Log.Debug($"Service started and listening on {BaseUrl}.");
			}
			catch (Exception e)
			{
				Log.Error("Error accured during web host start: " + e.Message);
				throw;
			}
        }

		protected virtual void SetupWebHost()
		{
			try
			{
				mWebHost = new WebHostBuilder()
					.UseContentRoot(Directory.GetCurrentDirectory())
					.UseKestrel()
					.UseUrls(BaseUrl)
					.UseStartup<STARTUP_TYPE>()
					.UseNLog()
					.Build();
			}
			catch (Exception e)
			{
				Log.Error("Error accured during web host setup:" + e.Message);
				throw;
			}
		}
    }
}
