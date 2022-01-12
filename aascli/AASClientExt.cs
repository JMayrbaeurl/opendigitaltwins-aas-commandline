using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace AAS.CLI
{
    public partial class Client : IClient
    {
        private string token;

        public string Token
        {
            get { return token; }
            set { token = value; }
        }

        partial void PrepareRequest(HttpClient client, System.Net.Http.HttpRequestMessage request, string url)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
