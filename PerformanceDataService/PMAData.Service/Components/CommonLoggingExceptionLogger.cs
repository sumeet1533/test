using System;
using System.Web.Http.ExceptionHandling;
using Common.Logging;

namespace Performance.Data.Service.Components
{
	/// <summary>A common logging exception logger.</summary>
	public class CommonLoggingExceptionLogger : ExceptionLogger
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CommonLoggingExceptionLogger"/> class.
		/// </summary>
		public CommonLoggingExceptionLogger()
		{
		}

		/// <summary>Logs the given context.</summary>
		/// <param name="context">The context.</param>
		public override void Log(ExceptionLoggerContext context)
		{
			Exception ex = context.Exception;
			if (ex != null)
			{
				ILog logger = LogManager.GetLogger<CommonLoggingExceptionLogger>();
				logger.Fatal(ex.Message, ex);
			}
		}
	}
}