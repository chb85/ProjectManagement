using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Microservice.Common.Configuration
{
    public class DataStoreConfiguration : ConfigurationElement
	{
		private const string IMPLEMENTING_TYPE = "implemntingType";

		[ConfigurationProperty(IMPLEMENTING_TYPE)]
		public string ImplementingType
		{
			get { return (string)this[IMPLEMENTING_TYPE]; }
			set { this[IMPLEMENTING_TYPE] = value; }
		}
	}
}
