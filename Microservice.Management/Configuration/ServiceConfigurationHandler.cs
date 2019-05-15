using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Xml;

namespace Microservice.Management.Configuration
{
	public class ServiceConfigurationHandler : ConfigurationSection
	{
		private const string SERVICES = "services";

		[ConfigurationProperty(SERVICES)]
		public ServiceConfigurationCollection Services
		{
			get { return (ServiceConfigurationCollection)this[SERVICES]; }
			set { this[SERVICES] = value; }
		}
	}
}
