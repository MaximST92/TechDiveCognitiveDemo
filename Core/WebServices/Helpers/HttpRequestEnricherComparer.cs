using System;
using System.Collections.Generic;
using maximst.CognitiveDemo.Core.WebServices.Interfaces;
namespace maximst.CognitiveDemo.Core.WebServices.Helpers
{
    public class HttpRequestEnricherComparer: IComparer<IHttpRequestEnricher>
    {
        public int Compare(IHttpRequestEnricher x, IHttpRequestEnricher y)
        {
            if (x == null && y != null) return -1;
            if (x != null && y == null) return 1;
            if (x == null && y == null || ReferenceEquals(x, y)) return 0;

            return x.Priority.CompareTo(y.Priority);
        }
    }
}
