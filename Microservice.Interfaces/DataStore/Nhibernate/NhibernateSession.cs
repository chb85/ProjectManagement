using Microservice.Common.Logging;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.Common.DataStore.Nhibernate
{
	public class NhibernateSession : IDataStoreSession
	{
		private ISessionFactory mSessionFactory;

        private ILog mLog;

        public NhibernateSession(ISessionFactory factory, ILog logger)
		{
            mLog = logger;
            mSessionFactory = factory;
		}

        public void CreateOrUpdate<T>(T definition)
        {
            var session = mSessionFactory.OpenSession();

            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(definition);
                    tx.Commit();

                    mLog.Debug($"Create {definition.ToString()} --> Finished tarnsaction on nhibernate store.");
                }
            }
            catch(Exception e)
            {
                mLog.Debug($"Error persisting {definition.ToString()} on nhibernate store: {e.Message}");
                throw;
            }
            finally
            {
                session.Close();
            }
        }

        public void Delete<T>()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> Query<T>()
		{
            var session = mSessionFactory.OpenSession();

            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    var result = session.Query<T>();
                    tx.Commit();

                    return result;
                }
            }
            catch (Exception e)
            {
                mLog.Debug($"Error querying Customer on nhibernate store: {e.Message}");
                throw;
            }
            finally
            {
                session.Close();
            }
        }
	}
}
