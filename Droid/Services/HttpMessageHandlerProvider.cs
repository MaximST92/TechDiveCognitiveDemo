using System;
using System.Net.Http;
using maximst.CognitiveDemo.Core.WebServices.Interfaces;
using maximst.CognitiveDemo.Droid.Helpers;
using MugenMvvmToolkit;
namespace maximst.CognitiveDemo.Droid.Services
{
    public class HttpMessageHandlerProvider : IHttpMessageHandlerProvider
    {
        public HttpMessageHandler Create() => ServiceProvider.Get<CustomHttpMessageHandler>();
    }
}
