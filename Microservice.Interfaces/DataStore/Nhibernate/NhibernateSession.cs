using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.Common.DataStore.Nhibernate
{
	public class NhibernateSession : IDataStoreSession
	{
		private ISessionFactory mSessionFactory;

		public NhibernateSession(ISessionFactory factory)
		{
			mSessionFactory = factory;
		}

		public void Delete<T>()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> Query<T>()
		{
			return mSessionFactory.OpenSession().Query<T>();
		}

		public void Update<T>()
		{
			throw new NotImplementedException();
		}
	}
}
