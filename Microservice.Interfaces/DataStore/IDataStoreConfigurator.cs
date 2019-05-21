using Microservice.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.Common.DataStore
{
    public interface IDataStoreConfigurator
    {
		IDataStoreSession Configure(DataStoreConfiguration config);

		void CreateDataStore();

		void UpdateDataStore();
    }
}
