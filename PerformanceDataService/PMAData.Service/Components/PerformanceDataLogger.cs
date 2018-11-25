using System;
using System.Collections.Generic;
using Common.Logging;
using Common.Logging.NLog;
using NLog;
using LogLevel = NLog.LogLevel;

namespace Performance.Data.Service.Components
{
	/// <summary>A performance data logger.</summary>
	public class PerformanceDataLogger : NLogLogger, ILog
	{
		private static readonly IReadOnlyDictionary<Common.Logging.LogLevel, LogLevel> LogLevelMapping = new Dictionary<Common.Logging.LogLevel, LogLevel>
		{
			{ Common.Logging.LogLevel.All, LogLevel.Trace },
			{ Common.Logging.LogLevel.Trace, LogLevel.Trace },
			{ Common.Logging.LogLevel.Debug, LogLevel.Debug },
			{ Common.Logging.LogLevel.Info, LogLevel.Info },
			{ Common.Logging.LogLevel.Warn, LogLevel.Warn },
			{ Common.Logging.LogLevel.Error, LogLevel.Error },
			{ Common.Logging.LogLevel.Fatal, LogLevel.Fatal },
			{ Common.Logging.LogLevel.Off, LogLevel.Off },
		};

		private readonly Logger InternalLogger;
		private readonly Func<string> GetRequestIdCallback;

		/// <summary>Initializes a new instance of the <see cref="PerformanceDataLogger"/> class.</summary>
		/// <param name="internalLogger">The internal logger.</param>
		public PerformanceDataLogger(Logger internalLogger) : this(internalLogger, () => null)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="PerformanceDataLogger"/> class.</summary>
		/// <param name="internalLogger">The internal logger.</param>
		/// <param name="getRequestIdCallback">The get request identifier callback.</param>
		public PerformanceDataLogger(Logger internalLogger, Func<string> getRequestIdCallback) : base(internalLogger)
		{
			this.InternalLogger = internalLogger;
			this.GetRequestIdCallback = getRequestIdCallback;
		}

		/// <summary>Writes an internal.</summary>
		/// <param name="logLevel">The log level.</param>
		/// <param name="message">The message.</param>
		/// <param name="exception">The exception.</param>
		protected override void WriteInternal(Common.Logging.LogLevel logLevel, object message, Exception exception)
		{
			LogEventInfo logEvent = new LogEventInfo
			(
				LogLevelMapping[logLevel],
				this.InternalLogger.Name,
				null,
				"{0}",
				new[] { message },
				exception
			);

			logEvent.Properties["RequestId"] = this.GetRequestIdCallback() ?? string.Empty;
			this.InternalLogger.Log(this.GetType(), logEvent);
		}
	}
}