using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.CustomerManagement.Bootstrap
{
    internal interface IServiceLoader
    {
        IServiceLoader LoadEnvirorment();
    }
}
