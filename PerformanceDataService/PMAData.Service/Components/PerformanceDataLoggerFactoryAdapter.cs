using System;
using Common.Logging;
using Common.Logging.Configuration;
using Common.Logging.NLog;

namespace Performance.Data.Service.Components
{
	/// <summary>A performance data logger factory adapter.</summary>
	public class PerformanceDataLoggerFactoryAdapter : NLogLoggerFactoryAdapter
	{
		private readonly Func<string, ILog> LoggerFactory = null;

		static PerformanceDataLoggerFactoryAdapter()
		{
			NLog.LogManager.AddHiddenAssembly(typeof(NLogLoggerFactoryAdapter).Assembly);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PerformanceDataLoggerFactoryAdapter"/> class.
		/// </summary>
		/// <param name="properties">The properties.</param>
		public PerformanceDataLoggerFactoryAdapter(NameValueCollection properties) : this(properties,
			name => new PerformanceDataLogger(NLog.LogManager.GetLogger(name)))
		{
		}

		/// <summary>Initializes a new instance of the <see cref="PerformanceDataLoggerFactoryAdapter"/> class.</summary>
		/// <param name="properties">The properties.</param>
		/// <param name="loggerFactory">The logger factory.</param>
		public PerformanceDataLoggerFactoryAdapter(NameValueCollection properties, Func<string, ILog> loggerFactory) :
			base(properties)
		{
			this.LoggerFactory = loggerFactory;
		}

		/// <summary>Creates configuration properties.</summary>
		/// <param name="configFilePath">Full pathname of the configuration file.</param>
		/// <returns>The new configuration properties.</returns>
		public static NameValueCollection CreateConfigurationProperties(string configFilePath)
		{
			return new NameValueCollection()
			{
				{ "configType", "FILE" },
				{ "configFile", configFilePath },
			};
		}

		/// <summary>Creates a logger.</summary>
		/// <param name="name">The name.</param>
		/// <returns>The new logger.</returns>
		protected override ILog CreateLogger(string name)
		{
			return this.LoggerFactory(name);
		}
	}
}