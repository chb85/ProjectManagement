using Microservice.Common.Logging;
using Nancy;
using Nancy.TinyIoc;

namespace Microservice.Common
{
	/// <summary>
	/// This is a general adaptation of the <see cref="DefaultNancyBootstrapper"/> which adds an instance of the 
	/// <see cref="ILog"/> interface to the injection container.
	/// </summary>
	public class CommonBootstrapper : DefaultNancyBootstrapper
    {
        private readonly ILog mLog;

		/// <summary>
		/// Initialize a new instance of the class <see cref="CommonBootstrapper"/>.
		/// </summary>
		/// <param name="log">The logger to apply to the injection container.</param>
		public CommonBootstrapper(ILog log)
        {
			mLog = log;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<ILog>(mLog);
        }
    }
}
