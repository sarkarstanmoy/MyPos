using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyPOS.Core.Extensions
{
    public static class HttpHeaderExtensions
    {
        public static void AddCustomHeader(this HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
        }

        public static void AddBearerToken(this HttpClient httpClient, string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", token);
        }
    }
}