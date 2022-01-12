using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace AAS.CLI
{
    public class AADTokenFactory : TokenFactory
    {
        private string _token;

        private string clientId;
        private string clientSecret;
        private string authority;
        private string scope;

        private readonly ILogger _logger;

        public AADTokenFactory(IConfiguration configuration, ILogger<AADTokenFactory> logger)
        {
            clientId = configuration["ClientId"];
            clientSecret = configuration["ClientSecret"];
            authority = configuration["Authority"];
            scope = configuration["Scope"];

            _logger = logger;
        }

        public AADTokenFactory(string aClientId, string aClientSecret, string anAuthoriy)
        {
            clientId = aClientId;
            clientSecret = aClientSecret;
            authority = anAuthoriy;
        }

        public string GetToken()
        {
            if (_token == null)
            {
                IConfidentialClientApplication app;
                app = ConfidentialClientApplicationBuilder.Create(clientId)
                                                          .WithClientSecret(clientSecret)
                                                          .WithAuthority(new Uri(authority))
                                                          .Build();

                _token = app.AcquireTokenForClient(new string[] 
                    { $"api://{scope}/.default" }).ExecuteAsync().GetAwaiter().GetResult().AccessToken;

                _logger.LogTrace($"Got token: {_token}");
            }

            return _token;
        }
    }
}
