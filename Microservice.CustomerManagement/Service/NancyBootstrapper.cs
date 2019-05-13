using Microsoft.Extensions.Configuration;
using Nancy;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.CustomerManagement.Service
{
    internal class NancyBootstrapper : DefaultNancyBootstrapper
    {
        private readonly IConfiguration mConfiguration;

        public NancyBootstrapper(IConfiguration config)
        {
            mConfiguration = config;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<IConfiguration>(mConfiguration);
        }
    }
}
