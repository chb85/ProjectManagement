using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microservice.Common.Configuration;
using NHibernate.Tool.hbm2ddl;
using NLog;
using System;
using System.Reflection;

namespace Microservice.Common.DataStore.Nhibernate
{
    public class NHibernateMsSQLConfigurator : IDataStoreConfigurator
	{
        private NHibernate.Cfg.Configuration mConfiguration;

        private ILogger mLog = LogManager.GetCurrentClassLogger();

        public IDataStoreSession Configure(DataStoreConfiguration config)
		{
			var sessionFactory = Fluently.Configure()
				.Database(MsSqlConfiguration.MsSql2012.ConnectionString(
					config.ConnectionString))
				.Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load(config.MappingAssambly)))
				.ExposeConfiguration(x => mConfiguration = x)
				.BuildSessionFactory();

			return new NhibernateSession(sessionFactory);
		}

		public void CreateDataStore()
		{
			if (mConfiguration == null)
				throw new ApplicationException("No configuration provided, " +
					"pleas configure NHibernate first. (Maybe call Configure())");

			new SchemaExport(mConfiguration)
				.Execute(true, true, false);
		}

        public void UpdateDataStore()
		{
			if (mConfiguration == null)
				throw new ApplicationException("No configuration provided, " +
					"pleas configure NHibernate first. (Maybe call Configure())");

			new SchemaUpdate(mConfiguration).Execute(true, true);
		}
	}
}
