using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Performance.Data.Service.Components
{
	/// <summary>A message handler base.</summary>
	public abstract class MessageHandlerBase : DelegatingHandler
	{
		/// <summary>Initializes a new instance of the <see cref="MessageHandlerBase"/> class.</summary>
		protected MessageHandlerBase()
		{
		}

		/// <summary>Sends the asynchronous.</summary>
		/// <param name="request">The request.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>A Task HttpResponseMessage.</returns>
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
			CancellationToken cancellationToken)
		{
			string requestInfo =
				$"{request.Method} {request.RequestUri} {request.GetActionDescriptor()?.ActionName ?? string.Empty}";
			var requestMessage = await request.Content.ReadAsByteArrayAsync();

			await this.IncomingMessageAsync(nameof(MessageHandlerBase),  request.GetRequestId(), requestInfo, requestMessage);

			HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

			IEnumerable<byte> responseMessage = Enumerable.Empty<byte>();

			if (!response.IsSuccessStatusCode)
			{
				responseMessage = Encoding.UTF8.GetBytes(response.ReasonPhrase);
			}

			await this.OutgoingMessageAsync(nameof(MessageHandlerBase), request.GetRequestId(), requestInfo,
				responseMessage.ToArray());

			return response;
		}

		/// <summary>Incoming message asynchronous.</summary>
		/// <param name="controllerName">Describing controller name.</param>
		/// <param name="requestId">Request Id.</param>
		/// <param name="requestInfo">Information describing the request.</param>
		/// <param name="message">The message.</param>
		/// <returns>A Task.</returns>
		protected abstract Task IncomingMessageAsync(string controllerName, string requestId, string requestInfo, byte[] message);

		/// <summary>Outgoing message asynchronous.</summary>
		/// <param name="controllerName">Describing controller name. </param>
		/// <param name="requestId">Request Id.</param>
		/// <param name="requestInfo">Information describing the request. </param>
		/// <param name="message">The message. </param>
		/// <returns>A Task.</returns>
		protected abstract Task OutgoingMessageAsync(string controllerName, string requestId, string requestInfo,
			byte[] message);
	}
}