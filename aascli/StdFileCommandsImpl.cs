using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AAS.CLI
{
    internal class StdFileCommandsImpl : FileCommand
    {
        IClient client;

        TokenFactory tokenFactory;

        private readonly ILogger _logger;

        public StdFileCommandsImpl(IClient aClient, TokenFactory fact, ILogger<StdFileCommandsImpl> logger)
        {
            client = aClient;
            tokenFactory = fact;
            _logger = logger;
        }

        public int RunCommand(FileOptions options)
        {
            client.BaseUrl = options.Url;
            client.Token = tokenFactory.GetToken();

            int result = 0;

            switch (options.Subcommand)
            {
                case "list-all":
                    result = RunListAllCommand(options);
                    break;
                default:
                    break;
            }

            return result;
        }

        protected int RunListAllCommand(FileOptions options)
        {
            ICollection<PackageDescription> packageDescs = client.PackagesAllAsync(options.AASId).GetAwaiter().GetResult();

            if (packageDescs != null && packageDescs.Count > 0)
            {
                _logger.LogTrace($"Operation GetAllAASXPackageIds returned:");

                foreach (var item in packageDescs)
                {
                    string jsonstring = JsonConvert.SerializeObject(item);

                    _logger.LogTrace($"   {jsonstring}");

                    Console.WriteLine(jsonstring);
                }
            } else
            {
                _logger.LogTrace($"Operation GetAllAASXPackageIds returned an empty result");
            }

            return 0;
        }
    }
}
