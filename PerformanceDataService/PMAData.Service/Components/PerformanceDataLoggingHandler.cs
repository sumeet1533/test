using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Performance.Data.Service.Components
{
	/// <summary>A performance data logging handler. This class cannot be inherited.</summary>
	public sealed class PerformanceDataLoggingHandler : MessageHandlerBase
	{
		private const string RequestId = "RequestId";

		/// <summary>Initializes a new instance of the <see cref="PerformanceDataLoggingHandler"/> class.</summary>
		public PerformanceDataLoggingHandler()
		{

		}

		/// <summary>Incoming message asynchronous.</summary>
		/// <param name="controllerName">Describing controller name.</param>
		/// <param name="requestId">A requestId.</param>
		/// <param name="requestInfo">Information describing the request.</param>
		/// <param name="message">The message.</param>
		/// <returns>A Task.</returns>
		protected override async Task IncomingMessageAsync(string controllerName, string requestId, string requestInfo, byte[] message)
		{
			await Task.Run(() =>
			{
				LogEventInfo logInfo = new LogEventInfo(LogLevel.Info, controllerName, $"Request: {requestInfo}\r\n{Encoding.UTF8.GetString(message)}");
				logInfo.Properties[RequestId] = requestId;
				LogManager.GetLogger(controllerName).Log(logInfo);
			});
		}

		/// <summary>Outgoing message asynchronous.</summary>
		/// <param name="controllerName">Describing controller name.</param>
		/// <param name="requestId">A requestId.</param>
		/// <param name="requestInfo">Information describing the request.</param>
		/// <param name="message">The message.</param>
		/// <returns>A Task.</returns>
		protected override async Task OutgoingMessageAsync(string controllerName, string requestId, string requestInfo, byte[] message)
		{
			await Task.Run(() =>
			{
				LogEventInfo logInfo = new LogEventInfo(LogLevel.Info, controllerName, $"Response: {requestInfo}\r\n{Encoding.UTF8.GetString(message)}");
				logInfo.Properties[RequestId] = requestId;
				LogManager.GetLogger(controllerName).Log(logInfo);
			});
		}
	}
}