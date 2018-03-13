using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace maximst.CognitiveDemo.Forms.DesignTime
{
	public class NullClientHandler : HttpMessageHandler
	{
		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			return Task.FromException<HttpResponseMessage>(new Exception("Design time handler"));
		}
	}
}
