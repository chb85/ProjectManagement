using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.Interfaces
{
    public interface IMicroservice
    {
        void Configure(IConfiguration config);

        void StartService();
    }
}
