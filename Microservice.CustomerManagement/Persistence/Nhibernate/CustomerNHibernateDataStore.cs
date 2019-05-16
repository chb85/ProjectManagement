using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.CustomerManagement.Persistence.Nhibernate
{
    public class CustomerNHibernateDataStore : ICustomerDataStore
    {
        private ISessionFactory mSession;

        public CustomerNHibernateDataStore(ISessionFactory session)
        {
            mSession = session;
        }

        public void CreateCustomer(string name)
        {
            throw new NotImplementedException();
        }
    }
}
