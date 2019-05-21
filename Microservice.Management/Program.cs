
using CommandLine;
using Microservice.Common;
using Microservice.Common.Configuration;
using Microservice.Common.Logging;
using Microservice.Common.Service;
using System;
using System.Collections;
using System.Configuration;
using System.Linq;
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
				var options = Parser.Default.ParseArguments<Options>(args)
					.WithParsed<Options>(o =>
					{
						if (o.CreateDataBases.Any())
						{

							return;
						}
						else if (o.UpdateDataBases.Any())
						{

							return;
						}

						Run();
					});
			}
			catch (Exception e)
			{
				mLog.Error($"Error during program start: {e.Message}\n{e.StackTrace}");
			}

			Console.Read();
		}

		private static void Run()
		{
			mLog = new ClassLog().Configure(Assembly.GetExecutingAssembly().Location + ".config");

			var serviceConfiguration = (ServiceConfigurationSection)ConfigurationManager
				.GetSection("microserviceConfiguration");

			foreach (ServiceConfiguration configuration in serviceConfiguration.Services)
				StartService(configuration);
		}

		private static void StartService(ServiceConfiguration config)
        {
            var microserviceType = typeof(MicroserviceBase<>);
            var startupType = Type.GetType(config.Host.StartupType + ", " + 
				config.Host.Assambly);

            if (startupType == null)
                throw new ApplicationException($"Could not resolve type {config.Host.StartupType} " +
                    $"in assambly {config.Host.Assambly}. Maybe the configuration has to be changed.");
     
            var combinedServiceType = microserviceType.MakeGenericType(startupType);
            dynamic instance = Activator.CreateInstance(combinedServiceType, config, mLog);
            instance.StartService();

			mLog.Debug($"Started service with configuration {config.Name} listening on " +
				$"{config.Host.BaseUrl}");
        }
    }
}
