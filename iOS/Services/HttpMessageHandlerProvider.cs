using System;
using System.Net.Http;
using MugenMvvmToolkit;
using maximst.CognitiveDemo.Core.WebServices.Interfaces;
using maximst.CognitiveDemo.iOS.Helpers;
namespace maximst.CognitiveDemo.iOS.Services
{
    public class HttpMessageHandlerProvider : IHttpMessageHandlerProvider
    {
        public HttpMessageHandler Create()  => ServiceProvider.Get<CustomHttpMessageHandler>();
    }
}
