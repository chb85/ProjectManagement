using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Microservice.Management.Configuration
{
	public class ServiceConfigurationCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new ServiceConfiguration();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			if (element is ServiceConfiguration)
				return ((ServiceConfiguration)element).Name;
			else
			{
				throw new ArgumentException(
					"Invalid configuration element type. Can only resolve the key of CCServiceConfiguration elements.",
					"element");
			}
		}
	}
}
