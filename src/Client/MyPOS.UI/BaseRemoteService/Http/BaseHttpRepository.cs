using Microsoft.AspNetCore.Components;
using MyPOS.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyPOS.UI.BaseRemoteService.Http
{
    public abstract class BaseHttpRepository
    {
        private IHttpClientFactory _clientFactory { get; set; }

        public BaseHttpRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public HttpClient GetClient(string name)
        {
            var client = _clientFactory.CreateClient(name);
            client.AddCustomHeader();
            client.AddBearerToken("abc");
            return client;
        }
    }
}