using Microservice.Common.Configuration;
using Microservice.Common.DataStore;
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
			var config = mEnvirorment.Resolve<ServiceConfiguration>();
			var dataStoreType = Type.GetType(config.DataStore.ConfigurationType + ", " + config.DataStore.Assambly);
			var dataStoreConfigurator = (IDataStoreConfigurator)Activator
				.CreateInstance(dataStoreType, mEnvirorment.Resolve<ILog>());

			if (dataStoreConfigurator == null)
				throw new ApplicationException($"Error resolving data stroe configuration." +
					$"Could not resolve component {config.DataStore.ConfigurationType} from " +
					$"assambly {config.DataStore.Assambly}.");

			mEnvirorment.Register<IDataStoreSession>(dataStoreConfigurator.Configure(config.DataStore));
			mEnvirorment.Register<ICustomerService>(new CustomerService(mEnvirorment));

			return this;
        }
    }
}
