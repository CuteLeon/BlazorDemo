using System.Net.Http;
using System.Threading;
using Microsoft.AspNetCore.Components;

namespace Covid.Client.Services
{
    public class HttpServiceBase
    {
        public HttpServiceBase(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }

        protected readonly HttpClient HttpClient;
    }
}
