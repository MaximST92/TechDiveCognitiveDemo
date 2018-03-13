using System.Net.Http;

namespace maximst.CognitiveDemo.Core.WebServices.Interfaces
{
    public interface IHttpMessageHandlerProvider
    {
        HttpMessageHandler Create();
    }
}
