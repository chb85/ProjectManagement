using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Microservice.Common.Configuration
{
    public class ServiceConfiguration : ConfigurationElement
	{
		private const string NAME = "name";

		private const string HOSTING_CONFIGURATION = "host";

		private const string DATA_STROE = "dataStore";

        [ConfigurationProperty(NAME)]
		public string Name
		{
			get { return (string)this[NAME]; }
			set { this[NAME] = value; }
		}

        [ConfigurationProperty(HOSTING_CONFIGURATION)]
		public HostConfiguration Host
		{
			get { return (HostConfiguration)this[HOSTING_CONFIGURATION]; }
			set { this[HOSTING_CONFIGURATION] = value; }
		}

		[ConfigurationProperty(DATA_STROE)]
		public DataStoreConfiguration DataStore
		{
			get { return (DataStoreConfiguration)this[DATA_STROE]; }
			set { this[DATA_STROE] = value; }
		}
    }
}
