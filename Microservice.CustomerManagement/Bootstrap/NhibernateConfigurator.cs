using System;
using System.Collections.Generic;
using System.Text;
using Microservice.Common.Configuration;
using Microservice.Common.Logging;
using Nancy.TinyIoc;

namespace Microservice.CustomerManagement.Bootstrap
{
    public class NhibernateConfigurator : IDataStoreConfigurator
    {
        private TinyIoCContainer mContainer;

        public NhibernateConfigurator(TinyIoCContainer container)
        {
            mContainer = container;

            if (!mContainer.CanResolve<ServiceConfiguration>())
                throw new ApplicationException($"There is no {nameof(ServiceConfiguration)} registered. " +
                    $"Cant proceed without configuration.");
        }

        public void Configure()
        {
            mContainer.Resolve<ILog>().Debug("Configuer Nhibernate here and register the session factory on the container.");
            //configure nhibernate

            // register nhibernate data store
        }
    }
}
