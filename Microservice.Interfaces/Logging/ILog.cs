using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.Common.Logging
{
    public interface ILog
    {
		ILog Configure(string configurationFile);

		void Trace(string message);

		void Debug(string message);

		void Error(string message);

		void Info(string message);

		void Fatal(string message);
	}
}
