using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.Common.DataStore
{
    public interface IDataStoreSession
    {
		IEnumerable<T> Query<T>();

		void Update<T>();

		void Delete<T>();
	}
}
