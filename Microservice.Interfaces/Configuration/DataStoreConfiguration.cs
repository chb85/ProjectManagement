using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Microservice.Common.Configuration
{
    public class DataStoreConfiguration : ConfigurationElement
	{
		private const string IMPLEMENTING_TYPE = "startupType";

        private const string CONNECTION_STRING = "connection";

        [ConfigurationProperty(IMPLEMENTING_TYPE)]
		public string StartupType
        {
			get { return (string)this[IMPLEMENTING_TYPE]; }
			set { this[IMPLEMENTING_TYPE] = value; }
		}

        [ConfigurationProperty(CONNECTION_STRING)]
        public string Connection
        {
            get { return (string)this[CONNECTION_STRING]; }
            set { this[CONNECTION_STRING] = value; }
        }
    }
}
