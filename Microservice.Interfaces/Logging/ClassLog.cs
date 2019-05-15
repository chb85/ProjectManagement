using NLog;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Microservice.Common.Logging
{
	public class ClassLog : ILog
	{
		public ILog Configure(string configurationFile)
		{
			LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(configurationFile);
			return this;
		}

		public void Trace(string message)
		{
			var stack = new StackFrame(1);
			LogManager.GetLogger(stack.GetMethod().DeclaringType.FullName).Trace(message);
		}

		public void Debug(string message)
		{
			var stack = new StackFrame(1);
			LogManager.GetLogger(stack.GetMethod().DeclaringType.FullName).Debug(message);
		}

		public void Info(string message)
		{
			var stack = new StackFrame(1);
			LogManager.GetLogger(stack.GetMethod().DeclaringType.FullName).Info(message);
		}

		public void Error(string message)
		{
			var stack = new StackFrame(1);
			LogManager.GetLogger(stack.GetMethod().DeclaringType.FullName).Error(message);
		}

		public void Fatal(string message)
		{
			var stack = new StackFrame(1);
			LogManager.GetLogger(stack.GetMethod().DeclaringType.FullName).Fatal(message);
		}
	}
}
