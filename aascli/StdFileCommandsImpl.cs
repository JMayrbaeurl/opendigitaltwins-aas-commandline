using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AAS.CLI
{
    internal class StdFileCommandsImpl : FileCommand
    {
        IClient client;

        TokenFactory tokenFactory;

        public StdFileCommandsImpl(IClient aClient, TokenFactory fact)
        {
            client = aClient;
            tokenFactory = fact;
        }

        public int RunCommand(FileOptions options)
        {
            client.BaseUrl = options.Url;
            client.Token = tokenFactory.GetToken();

            ICollection<PackageDescription> packageDescs = client.PackagesAllAsync(null).GetAwaiter().GetResult();

            if (packageDescs != null && packageDescs.Count > 0)
            {
                foreach (var item in packageDescs)
                {
                    string jsonstring = JsonConvert.SerializeObject(item);
                    Console.WriteLine(jsonstring);
                }
            }

            return 0;
        }
    }
}
