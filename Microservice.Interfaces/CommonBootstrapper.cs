using Microservice.Common.Logging;
using Microsoft.Extensions.Configuration;
using Nancy;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.Common
{
    public class CommonBootstrapper : DefaultNancyBootstrapper
    {
        private readonly ILog mLog;

        public CommonBootstrapper(ILog log)
        {
			mLog = log;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<ILog>(mLog);
        }
    }
}
