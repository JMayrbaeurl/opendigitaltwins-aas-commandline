using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace AAS.CLI
{
    [Verb("file", HelpText = "Manage AASX package files in library")]
    class FileOptions
    { 
        [Option('u', "url", Required = true, HelpText = "AAS API Url")]
        public string Url { get; set; }
    }
    [Verb("shell", HelpText = "Manage AAS shells")]
    class ShellOptions
    { //normal options here
    }

    internal class Program
    {
        static int Main(string[] args) => Parser.Default.ParseArguments<FileOptions, ShellOptions>(args)
            .MapResult(
                (FileOptions options) => RunFileAndReturnExitCode(options),
                (ShellOptions options) => RunShellAndReturnExitCode(options),
                errors => 1);

        static int RunFileAndReturnExitCode(FileOptions options)
        {
            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    services.AddTransient<FileCommand, StdFileCommandsImpl>();
                    services.AddSingleton<IClient, Client>();
                    services.AddSingleton<TokenFactory, AADTokenFactory>();
                    services.AddHttpClient();
                })
                .Build();

            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            FileCommand cmd = provider.GetRequiredService<FileCommand>();
            int result = cmd.RunCommand(options);

            host.RunAsync().GetAwaiter().GetResult();

            return result;
        }

        static int RunShellAndReturnExitCode(ShellOptions options)
        {
            return 0;
        }
    }
}
