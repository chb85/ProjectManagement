
using Microservice.Common;
using Microservice.Common.Configuration;
using Microservice.Common.Logging;
using Microservice.Common.Service;
using System;
using System.Collections;
using System.Configuration;
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

				var serviceConfiguration = (ServiceConfigurationSection)ConfigurationManager
					.GetSection("microserviceConfiguration");

				foreach (ServiceConfiguration configuration in serviceConfiguration.Services)
					StartService(configuration);
			}
			catch (Exception e)
			{
				mLog.Error($"Error during program start: {e.Message}\n{e.StackTrace}");
			}

			Console.Read();
		}

        private static void StartService(ServiceConfiguration configuration)
        {
            var microserviceType = typeof(MicroserviceBase<>);
            var startupType = Type.GetType(configuration.HostConfiguration.StartupType + ", " + configuration.Assambly);
            var combinedServiceType = microserviceType.MakeGenericType(startupType);
            dynamic instance = Activator.CreateInstance(combinedServiceType, configuration, mLog);
            instance.StartService();

			mLog.Debug($"Started service with configuration {configuration.Name} listening on " +
				$"{configuration.HostConfiguration.BaseUrl}");
        }
    }
}
