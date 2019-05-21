using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.CustomerManagement.Persistence.Nhibernate.Data
{
    public class Customer
    {
        public virtual Guid Id { get; set; }

        public virtual string CustomerId { get; set; }

        public virtual string Company { get; set; }

        public virtual string Surname { get; set; }

        public virtual string Name { get; set; }

        public virtual string Title { get; set; }

        public virtual string Salutation { get; set; }

        public virtual string EMail { get; set; }

        public virtual string Street { get; set; }

        public virtual string Postcode { get; set; }

        public virtual string City { get; set; }

        public virtual string Country { get; set; }

        public virtual string MobilePhone { get; set; }

        public virtual string Phone { get; set; }
    }
}
