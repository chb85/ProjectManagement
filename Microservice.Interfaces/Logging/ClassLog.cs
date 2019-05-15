using NLog;
using System.Diagnostics;

namespace Microservice.Common.Logging
{
	/// <summary>
	/// An implementation of the interface <see cref="ILog"/> which uses NLog for logging.
	/// The logger uses reflection to determine the calling class and creates a NLogger of the corresponding type
	/// to log the passed message.
	/// </summary>
	public class ClassLog : ILog
	{
		/// <summary>
		/// Configure the logger with the config file found under the passed file location.
		/// </summary>
		/// <param name="configurationFile">The full path to the config file.</param>
		/// <returns></returns>
		public ILog Configure(string configurationFile)
		{
			LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(configurationFile);
			return this;
		}

		/// <summary>
		/// Log message on trace level.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		public void Trace(string message)
		{
			var stack = new StackFrame(1);
			LogManager.GetLogger(stack.GetMethod().DeclaringType.FullName).Trace(message);
		}

		/// <summary>
		/// Log message on debug level.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		public void Debug(string message)
		{
			var stack = new StackFrame(1);
			LogManager.GetLogger(stack.GetMethod().DeclaringType.FullName).Debug(message);
		}

		/// <summary>
		/// Log message on info level.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		public void Info(string message)
		{
			var stack = new StackFrame(1);
			LogManager.GetLogger(stack.GetMethod().DeclaringType.FullName).Info(message);
		}

		/// <summary>
		/// Log message on error level.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		public void Error(string message)
		{
			var stack = new StackFrame(1);
			LogManager.GetLogger(stack.GetMethod().DeclaringType.FullName).Error(message);
		}

		/// <summary>
		/// Log message on fatal level.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		public void Fatal(string message)
		{
			var stack = new StackFrame(1);
			LogManager.GetLogger(stack.GetMethod().DeclaringType.FullName).Fatal(message);
		}
	}
}
