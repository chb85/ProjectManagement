using Microservice.Common.DataStore;
using Microservice.Common.Logging;
using Microservice.CustomerManagement.Persistence.Nhibernate.Data;
using Microservice.CustomerManagement.Service;
using Microsoft.Extensions.Configuration;
using Nancy;
using Nancy.TinyIoc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Microservice.CustomerManagement.IPC
{
    public class Routes : NancyModule
    {
        public Routes(ICustomerService servcie) : base("/customers")
        {
			Get("/", _ => GetCustomers(servcie));

			Post("/", _ => CreateCustomer(servcie, Deserialize(Request.Body)));
        }

        private bool CreateCustomer(ICustomerService service, Customer customer)
        {
            return true;
        }

		private IEnumerable<Customer> GetCustomers(ICustomerService service)
		{
			return null;
		}

		public Customer Deserialize(Stream body)
		{
			try
			{
				using (var reader = new StreamReader(body))
					return JsonConvert.DeserializeObject<Customer>(reader.ReadToEnd());
			}
			catch (Exception ex)
			{
				mLog.Error($"The group usage specification deserializing has failed due to: {ex.Message}");
				throw;
			}
		}

	}
}
