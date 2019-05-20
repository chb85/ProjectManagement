using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microservice.Common.Configuration;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Microservice.Common.DataStore
{
    public class NHibernateMsSQLConfigurator
    {
        private NHibernate.Cfg.Configuration mConfiguration;

        public ISessionFactory Configure(DataStoreConfiguration config)
        {
           return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(
                    config.ConnectionString))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load(config.Assambly)))
                .ExposeConfiguration(x => mConfiguration = x)
                .BuildSessionFactory();
        }

        public void BuildSchema(NHibernate.Cfg.Configuration config, bool create = false, bool update = false)
        {
            if (mConfiguration == null)
                throw new ApplicationException("No configuration provided, " +
                    "pleas configure NHibernate first. (Maybe call Configure())");

            if (create)
                new SchemaExport(mConfiguration).Create(false, true);
            else
                new SchemaUpdate(mConfiguration).Execute(false, update);
        }
    }
}
