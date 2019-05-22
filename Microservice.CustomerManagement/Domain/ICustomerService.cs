using Microservice.CustomerManagement.Persistence.Nhibernate.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.CustomerManagement.Service
{
    public interface ICustomerService
    {
		IEnumerable<Customer> GetCustomers();
    }
}
