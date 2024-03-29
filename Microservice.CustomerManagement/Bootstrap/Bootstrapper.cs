﻿using Microservice.Common.Configuration;
using Microservice.CustomerManagement.Domain.Service;
using Microservice.CustomerManagement.Service;
using Nancy;
using Nancy.TinyIoc;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.CustomerManagement.Bootstrap
{
    internal class Bootstrapper : DefaultNancyBootstrapper
    {
        private readonly ServiceConfiguration mConfiguration;

        /// <summary>
        /// Initialize a new instance of the class <see cref="CommonBootstrapper"/>.
        /// </summary>
        /// <param name="log">The logger to apply to the injection container.</param>
        public Bootstrapper(ServiceConfiguration config)
        {
            mConfiguration = config;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<ServiceConfiguration>(mConfiguration);
            container.Register<IServiceLoader>(new ServiceLoader(container));

            container.Resolve<IServiceLoader>().LoadEnvirorment();
        }
    }
}
