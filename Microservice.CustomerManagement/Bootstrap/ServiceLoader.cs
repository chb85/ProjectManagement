using Microservice.Common.Configuration;
using Microservice.Common.Logging;
using Microservice.CustomerManagement.Domain.Service;
using Microservice.CustomerManagement.Persistence;
using Microservice.CustomerManagement.Persistence.Nhibernate;
using Microservice.CustomerManagement.Service;
using Nancy.TinyIoc;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.CustomerManagement.Bootstrap
{
    internal class ServiceLoader : IServiceLoader
    {
        private TinyIoCContainer mEnvirorment;


        public ServiceLoader(TinyIoCContainer container)
        {
            mEnvirorment = container;
        }

        public IServiceLoader LoadEnvirorment()
        {
            mEnvirorment.Register<ICustomerService>(new CustomerService(mEnvirorment));

			// use reflection to get implementing type of IDataStore and call Configure
			// to register the components neede for the DataStore
			var config = mEnvirorment.Resolve<ServiceConfiguration>();
			var dataStoreType = Type.GetType(config.DataStore.ConfigurationType + ", " + config.DataStore.Assambly);
			var dataStoreConfigurator = (IDataStoreConfigurator)Activator
				.CreateInstance(dataStoreType, mEnvirorment);

			if (dataStoreConfigurator == null)
				throw new ApplicationException($"Error resolving data stroe configuration." +
					$"Could not resolve component {config.DataStore.ConfigurationType} from " +
					$"assambly {config.DataStore.Assambly}.");

			dataStoreConfigurator.Configure();

            mEnvirorment.Resolve<ILog>().Debug("Service envirorment has been set up.");

            return this;
        }
    }
}
