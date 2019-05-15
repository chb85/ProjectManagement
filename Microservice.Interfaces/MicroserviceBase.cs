using Microservice.Common.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Microservice.Common
{
	/// <summary>
	/// This class is a general implementation of a web host, using the Kestrel server.
	/// The startup class definition must provide a method Configure().
	/// </summary>
	/// <typeparam name="STARTUP_TYPE">The type of the startup class.</typeparam>
	public class MicroserviceBase<STARTUP_TYPE> where STARTUP_TYPE : class
	{
		private IWebHost mWebHost;

		private ILog mLog;

		/// <summary>
		/// The base url and port this host is listening on.
		/// Format: url:port
		/// </summary>
		public string BaseUrl { get; private set; }

		/// <summary>
		/// Initialize a new instance of <see cref="MicroserviceBase[STARTUP_TYPE]"/>.
		/// </summary>
		/// <param name="baseUrl">The base url and port where the host should listen.</param>
		/// <param name="log">The logger.</param>
		public MicroserviceBase(string baseUrl, ILog log)
		{
			BaseUrl = baseUrl;
			mLog = log;
		}

		/// <summary>
		/// Setup the host and start listening on the defined url:port.
		/// </summary>
		/// <exception cref="Exception">Throws an exception when the setup or the start fails.</exception>
		public virtual void StartService()
		{
			try
			{
				mWebHost = SetupWebHost();
				mWebHost.Start();
			}
			catch (Exception e)
			{
				mLog.Error($"Error during web host start: {e.Message}");
				throw;
			}
		}

		protected virtual IWebHost SetupWebHost()
		{
			return new WebHostBuilder()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseKestrel()
				.UseUrls(BaseUrl)
				.ConfigureServices(x => x.AddSingleton<ILog>(mLog))
				.UseStartup<STARTUP_TYPE>()
				.Build();
		}
	}
}
