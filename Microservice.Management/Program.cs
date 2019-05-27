
using CommandLine;
using Microservice.Common;
using Microservice.Common.Configuration;
using Microservice.Common.DataStore;
using Microservice.Common.Service;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace Microservice.Management
{
	class Program
    {
		private static ILogger mLog;

		private static  ServiceConfigurationSection mServiceConfiguration;

		static void Main(string[] args)
		{
			try
			{
				var logConfig = Assembly.GetExecutingAssembly().Location + ".config";
                LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(logConfig);
                mLog = LogManager.GetCurrentClassLogger();

                mServiceConfiguration = (ServiceConfigurationSection)ConfigurationManager
					.GetSection("microserviceConfiguration");

				var options = Parser.Default.ParseArguments<Options>(args)
					.WithParsed<Options>(o =>
					{
						if (o.CreateDataBases.Any())
						{
							CreateDataStores(o.CreateDataBases);
                            mLog.Debug("Database was created...");

							return;
						}
						else if (o.UpdateDataBases.Any())
						{
							UpdateDataStores(o.UpdateDataBases);
							return;
						}

						RunServices();
					});
			}
			catch (Exception e)
			{
				mLog.Error($"{e.Message}\n{e.StackTrace}");
			}

			Console.Read();
		}

		private static void RunServices()
		{
			foreach (ServiceConfiguration configuration in mServiceConfiguration.Services)
				StartService(configuration);
		}

		private static void CreateDataStores(IEnumerable<string> createDataBases)
		{
			foreach (var serviceName in createDataBases)
			{
				var serviceconfig = mServiceConfiguration.Services.Cast<ServiceConfiguration>()
					.FirstOrDefault(s => s.Name == serviceName);

				new DataBaseBuilder().CreateDataBase(serviceconfig.DataStore);
			}
		}

		private static void UpdateDataStores(IEnumerable<string> createDataBases)
		{
			foreach (var serviceName in createDataBases)
			{
				var serviceconfig = mServiceConfiguration.Services.Cast<ServiceConfiguration>()
					.FirstOrDefault(s => s.Name == serviceName);

				new DataBaseBuilder().UpdateDataBase(serviceconfig.DataStore);
			}
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
            dynamic instance = Activator.CreateInstance(combinedServiceType, config);
            instance.StartService();

			mLog.Debug($"Started service with configuration {config.Name} listening on " +
				$"{config.Host.BaseUrl}");
        }
    }
}
