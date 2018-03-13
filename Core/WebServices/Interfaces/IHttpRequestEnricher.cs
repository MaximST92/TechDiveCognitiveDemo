using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace maximst.CognitiveDemo.Core.WebServices.Interfaces
{
    public interface IHttpRequestEnricher
    {
        Task Enrich(HttpRequestMessage request, CancellationToken cancellationToken);
        int Priority { get; }
    }
}
