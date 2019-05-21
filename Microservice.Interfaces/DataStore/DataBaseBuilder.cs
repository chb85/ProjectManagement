using Microservice.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.Common.DataStore
{
    public class DataBaseBuilder
    {
		public void CreateDataBase(DataStoreConfiguration config)
		{
			var dataStoreType = Type.GetType(config.ConfigurationType + ", " + config.Assambly);
			var dataStoreConfigurator = (IDataStoreConfigurator)Activator
			.CreateInstance(dataStoreType);

			dataStoreConfigurator.Configure(config);
			dataStoreConfigurator.CreateDataStore();
		}

		public void UpdateDataBase(DataStoreConfiguration config)
		{
			var dataStoreType = Type.GetType(config.ConfigurationType + ", " + config.Assambly);
			var dataStoreConfigurator = (IDataStoreConfigurator)Activator
			.CreateInstance(dataStoreType);

			dataStoreConfigurator.Configure(config);
			dataStoreConfigurator.UpdateDataStore();
		}
	}
}
