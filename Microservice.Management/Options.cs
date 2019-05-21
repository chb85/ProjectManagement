using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.Management
{
    internal class Options
    {
		[Option('c', "Add all names of services where a data base schema shall be created.")]
		public IEnumerable<string> CreateDataBases { get; set; }

		[Option('u', "Add all names of services where a data base schema shall be updated.")]
		public IEnumerable<string> UpdateDataBases { get; set; }
	}
}
