using Microservice.Common.Logging;
using Microservice.Common.Service;
using NUnit.Framework;
using System;

namespace Microservice.Common.Test
{
	/// <summary>
	/// Unit tests for the class <see cref="MicroserviceBase[STARTUP_TYPE]"/>.
	/// </summary>
	[TestFixture]
    public class MicroserviceBaseTest
    {
		/// <summary>
		/// Test that after calling StartService of a new instance of the tested class
		/// the web host is available under the address provided by the configuration.
		/// </summary>
		[Test]
		public void StartService_MakesWebHostAvailible_ListeningOn(string baseUrl)
		{
			
		}
    }
}
