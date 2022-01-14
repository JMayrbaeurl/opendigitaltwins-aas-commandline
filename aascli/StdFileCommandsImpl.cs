using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
                case "create":
                    result = RunCreateCommand(options);
                    break;
                case "delete":
                    result = RunDeleteCommand(options);
                    break;
                case "update":
                    result = RunUpdateCommand(options);
                    break;
                case "download":
                    result = RunDownloadCommand(options);
                    break;
                default:
                    result = -1;
                    break;
            }

            return result;
        }

        protected int RunUpdateCommand(FileOptions options)
        {
            if (options.PackageId == null || options.PackageId.Length == 0)
            {
                Console.WriteLine("Package id must not be empty");
                return -1;
            }

            if (options.PackageFilePath != null || options.Filename != null || options.AASId != null)
            {
                PackagesBody packagesBody = new PackagesBody() { FileName = options.Filename};
                if (options.PackageFilePath != null)
                {
                    if (!File.Exists(options.PackageFilePath))
                    {
                        Console.WriteLine($"File '{options.PackageFilePath}' doesn't exist");
                        return -1;
                    }
                    byte[] file = File.ReadAllBytes(options.PackageFilePath);
                    packagesBody.File = file;
                }
                if (options.AASId != null)
                {
                    packagesBody.AasIds = options.AASId.Split(',');
                }

                PackageDescription aDesc = client.PackagesPUTAsync(options.PackageId, packagesBody).GetAwaiter().GetResult();

                if (aDesc != null)
                {
                    _logger.LogTrace($"Operation PutAASXPackage returned package description with id: {aDesc.PackageId}");
                    Console.WriteLine(JsonConvert.SerializeObject(aDesc));
                }
                else
                {
                    _logger.LogTrace($"Operation PutAASXPackage returned an empty result");
                }
            }

            return 0;
        }

        protected int RunDownloadCommand(FileOptions options)
        {
            if (options.PackageId == null || options.PackageId.Length == 0)
            {
                Console.WriteLine("Package id must not be empty");
                return -1;
            }

            if (options.Directory == null || options.Directory.Length == 0)
            {
                Console.WriteLine("Directory for AASX package file must be specified");
                return -1;
            }
            else
            {
                if (!Directory.Exists(options.Directory))
                {
                    Console.WriteLine($"Directory '{options.Directory}' doesn't exist");
                    return -1;
                }
            }

            byte[] packageBytes = client.PackagesGETAsync(options.PackageId).GetAwaiter().GetResult();
            if (packageBytes != null && packageBytes.Length > 0)
            {
                string filePath = Path.Combine(Path.GetFullPath(options.Directory), $"{options.PackageId}.aasx");
                File.WriteAllBytes(filePath, packageBytes);

                _logger.LogTrace($"Operation GetAASXByPackageId returned package in {filePath}");
                Console.WriteLine(filePath);
            }
            else
            {
                _logger.LogTrace($"Operation GetAASXByPackageId returned an empty result");
            }

            return 0;
        }

        protected int RunDeleteCommand(FileOptions options)
        {
            if (options.PackageId == null || options.PackageId.Length == 0)
            {
                Console.WriteLine("Package id must not be empty");
                return -1;
            }

            client.PackagesDELETEAsync(options.PackageId).GetAwaiter().GetResult();

            return 0;
        }

        protected int RunCreateCommand(FileOptions options)
        {
            if (options.PackageFilePath == null || options.PackageFilePath.Length == 0)
            {
                Console.WriteLine("File path to AASX package file must be specified");
                return -1;
            } else
            {
                if (!File.Exists(options.PackageFilePath))
                {
                    Console.WriteLine($"File '{options.PackageFilePath}' doesn't exist");
                    return -1;
                }
            }

            byte[] file = File.ReadAllBytes(options.PackageFilePath);

            PackagesBody packageBody = new PackagesBody() { File = file, FileName = Path.GetFileName(options.PackageFilePath)};
            if (options.AASId != null && options.AASId.Length > 0)
            {
                packageBody.AasIds = options.AASId.Split(',');
            }

            PackageDescription aDesc = client.PackagesPOSTAsync(packageBody).GetAwaiter().GetResult();

            if (aDesc != null)
            {
                _logger.LogTrace($"Operation PostAASXPackage returned package description with id: {aDesc.PackageId}");
                Console.WriteLine(JsonConvert.SerializeObject(aDesc));
            }
            else
            {
                _logger.LogTrace($"Operation PostAASXPackage returned an empty result");
            }

            return 0;
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
