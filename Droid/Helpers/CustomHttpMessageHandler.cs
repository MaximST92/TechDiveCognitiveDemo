using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using maximst.CognitiveDemo.Core.WebServices.Helpers;
using maximst.CognitiveDemo.Core.WebServices.Interfaces;

namespace maximst.CognitiveDemo.Droid.Helpers
{
    public class CustomHttpMessageHandler: Xamarin.Android.Net.AndroidClientHandler
    {
        readonly SortedSet<IHttpRequestEnricher> _requestEnrichers;

        public CustomHttpMessageHandler(IEnumerable<IHttpRequestEnricher> requestEnrichers)
        {
            _requestEnrichers = new SortedSet<IHttpRequestEnricher>(requestEnrichers ?? Enumerable.Empty<IHttpRequestEnricher>(), new HttpRequestEnricherComparer());
        }

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			foreach (var enricher in _requestEnrichers)
			{
				await enricher.Enrich(request, cancellationToken).ConfigureAwait(false);
			}

			return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
		}
    }
}
