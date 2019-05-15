
using Microservice.Common;
using System;
using System.Configuration;
using Microservice.CustomerManagement.Service;
using Microservice.Management.Configuration;
using Microsoft.Extensions.Configuration;
using NLog.Web;
using NLog;
using Microservice.Common.Logging;
using System.Reflection;

namespace Microservice.Management
{
    class Program
    {
		private static ILog mLog;

		static void Main(string[] args)
		{
			try
			{
				mLog = new ClassLog().Configure(Assembly.GetExecutingAssembly().Location + ".config");

				var serviceConfiguration = (ServiceConfigurationHandler)ConfigurationManager
					.GetSection("microserviceConfiguration");

				foreach (ServiceConfiguration configuration in serviceConfiguration.Services)
					StartService(configuration);
			}
			catch (Exception e)
			{
				mLog.Error($"Error during program start: {e.Message}");
			}

			Console.Read();
		}

		private static void StartService(ServiceConfiguration configuration)
		{
			try
			{
				var microserviceType = typeof(MicroserviceBase<>);
				var startupType = Type.GetType(configuration.StartupType + ", Microservice.CustomerManagement");
				var combinedServiceType = microserviceType.MakeGenericType(startupType);
				dynamic instance = Activator.CreateInstance(combinedServiceType, configuration.BaseUrl, mLog);
				instance.StartService();

				mLog.Debug($"Started service {configuration.Name} listening on {configuration.BaseUrl}");
			}
			catch (Exception e)
			{
				mLog.Error($"Error during service startup of service {configuration.Name} on " +
					$"{ configuration.BaseUrl}: {e.Message}");
				throw;
			}
		}
    }
}
