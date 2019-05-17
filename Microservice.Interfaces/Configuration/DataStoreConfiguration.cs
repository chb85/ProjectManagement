using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Microservice.Common.Configuration
{
    public class DataStoreConfiguration : ConfigurationElement
	{
		private const string IMPLEMENTING_TYPE = "dsConfigType";

        private const string CONFIG_FILE = "dsConfigFile";

		private const string ASSAMBLY = "assambly";

		private const string CONNECTION_STRING = "connectionstring";

		[ConfigurationProperty(IMPLEMENTING_TYPE)]
		public string ConfigurationType
        {
			get { return (string)this[IMPLEMENTING_TYPE]; }
			set { this[IMPLEMENTING_TYPE] = value; }
		}

		[ConfigurationProperty(ASSAMBLY)]
		public string Assambly
		{
			get { return (string)this[ASSAMBLY]; }
			set { this[ASSAMBLY] = value; }
		}

		[ConfigurationProperty(CONFIG_FILE)]
		public string ConfigFileLocation
		{
			get { return (string)this[CONFIG_FILE]; }
			set { this[CONFIG_FILE] = value; }
		}

		[ConfigurationProperty(CONNECTION_STRING)]
		public string ConnectionString
		{
			get { return (string)this[CONNECTION_STRING]; }
			set { this[CONNECTION_STRING] = value; }
		}
	}
}
