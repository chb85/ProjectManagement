
using Microservice.Common;
using System;
using System.Configuration;
using Microservice.CustomerManagement.Service;

namespace Microservice.Management
{
    class Program
    {
		static void Main(string[] args)
		{
			var log = new Logger()
				.Configure(System.Reflection.Assembly.GetExecutingAssembly().Location + ".config");

			var customerService = new MicroserviceBase<Startup>("http://0.0.0.0:9001", log);
			customerService.StartService();

			Console.Read();
		}
    }
}
