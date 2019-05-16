using Microservice.Common.Configuration;
using Microservice.Common.Logging;
using Microservice.CustomerManagement.Domain.Service;
using Microservice.CustomerManagement.Service;
using Nancy;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.CustomerManagement.Routes
{
    internal class Bootstrapper : DefaultNancyBootstrapper
    {
        private readonly ILog mLog;

        private readonly ServiceConfiguration mConfiguration;

        /// <summary>
        /// Initialize a new instance of the class <see cref="CommonBootstrapper"/>.
        /// </summary>
        /// <param name="log">The logger to apply to the injection container.</param>
        public Bootstrapper(ServiceConfiguration config ,ILog log)
        {
            mLog = log;
            mConfiguration = config;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register<ILog>(mLog);
            container.Register<ServiceConfiguration>(mConfiguration);
            container.Register<ICustomerService>(new CustomerService());
        }
    }
}
