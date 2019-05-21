using Microservice.Common.DataStore;
using Microservice.Common.Logging;
using Microservice.CustomerManagement.Persistence.Nhibernate.Data;
using Microservice.CustomerManagement.Service;
using Microsoft.Extensions.Configuration;
using Nancy;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.CustomerManagement.IPC
{
    public class Routes : NancyModule
    {
        private TinyIoCContainer mContainer;

        private ILog mLog;

        public Routes(TinyIoCContainer servcie, ILog logger) : base("/customers")
        {
            mContainer = servcie;
            mLog = logger;

            Post("/", _ => CreateCustomer());
        }

        private bool CreateCustomer()
        {
            mContainer.Resolve<IDataStoreSession>().CreateOrUpdate<Customer>(
                new Customer
                {
                    Id = new Guid("5BEAFB18-0112-4327-A585-1DE5DEF0F732"),
                    Title = "Prof.",
                    Company = "Test GmbH",
                    City = "Testtown",
                    Country = "Testland",
                    CustomerId = "1",
                    EMail = "test@test.de",
                    MobilePhone = "0101010101010",
                    Name = "Testperson",
                    Postcode  = "0000000",
                    Salutation = "Herr",
                    Street = "Teststrret",
                    Surname = "Heiner",
                    Phone = "000000000000"
                });

            return true;
        }


    }
}
