using Microservice.CustomerManagement.Service;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.CustomerManagement.Domain.Service
{
    public class CustomerService : ICustomerService
	{
        private TinyIoCContainer mContainer;

        public CustomerService(TinyIoCContainer container)
        {
            mContainer = container;
        }

        public string Name { get => "Haalo"; }
    }
}
