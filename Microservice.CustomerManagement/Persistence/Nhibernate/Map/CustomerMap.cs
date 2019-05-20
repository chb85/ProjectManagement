using FluentNHibernate.Mapping;
using Microservice.CustomerManagement.Persistence.Nhibernate.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.CustomerManagement.Persistence.Nhibernate.Map
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Salutation).Length(64).Not.Nullable();
            Map(x => x.Title).Length(64).Nullable();
            Map(x => x.Name).Length(64).Not.Nullable();
            Map(x => x.Surname).Length(64).Not.Nullable();
            Map(x => x.Company).Length(64).Nullable();
            Map(x => x.City).Length(64).Not.Nullable();
            Map(x => x.Street).Length(64).Not.Nullable();
            Map(x => x.Country).Length(64).Not.Nullable();
            Map(x => x.Postcode).Length(64).Not.Nullable();
            Map(x => x.Phone).Length(64).Nullable();
            Map(x => x.MobilePhone).Length(64).Nullable();
        }
    }
}
