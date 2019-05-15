using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Microservice.Management.Configuration
{
    public class ServiceConfiguration : ConfigurationElement
	{
		private const string NAME = "name";

		private const string STARTUP_TYPE = "startupType";

		private const string BASE_URL = "baseUrl";

		private const string CONNECTION_STRING = "connectionString";

		[ConfigurationProperty(NAME)]
		public string Name
		{
			get { return (string)this[NAME]; }
			set { this[NAME] = value; }
		}

		[ConfigurationProperty(STARTUP_TYPE)]
		public string StartupType
		{
			get { return (string)this[STARTUP_TYPE]; }
			set { this[STARTUP_TYPE] = value; }
		}

		[ConfigurationProperty(BASE_URL)]
		public string BaseUrl
		{
			get { return (string)this[BASE_URL]; }
			set { this[BASE_URL] = value; }
		}

		[ConfigurationProperty(CONNECTION_STRING)]
		public string ConnectionString
		{
			get { return (string)this[CONNECTION_STRING]; }
			set { this[CONNECTION_STRING] = value; }
		}
	}
}
