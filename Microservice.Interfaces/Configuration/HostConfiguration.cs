using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Microservice.Common.Configuration
{
    public class HostConfiguration : ConfigurationElement
	{
		private const string BASE_URL = "baseUrl";

		private const string STARTUP_TYPE = "startupType";

		private const string ASSAMBLY = "assambly";

		[ConfigurationProperty(BASE_URL)]
		public string BaseUrl
		{
			get { return (string)this[BASE_URL]; }
			set { this[BASE_URL] = value; }
		}

		[ConfigurationProperty(STARTUP_TYPE)]
		public string StartupType
		{
			get { return (string)this[STARTUP_TYPE]; }
			set { this[STARTUP_TYPE] = value; }
		}

		[ConfigurationProperty(ASSAMBLY)]
		public string Assambly
		{
			get { return (string)this[ASSAMBLY]; }
			set { this[ASSAMBLY] = value; }
		}
	}
}
