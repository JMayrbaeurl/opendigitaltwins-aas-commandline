using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AAS.CLI
{
    [TestClass]
    public class AADTokenFactoryTests
    {
        private IConfiguration GetConfiguration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<AADTokenFactoryTests>()
                .Build();

            return config;
        }

        [TestMethod]
        public void TestGetToken()
        {
            IConfiguration configuration = GetConfiguration();

            AADTokenFactory factory = new AADTokenFactory(configuration["ClientId"], configuration["ClientSecret"], configuration["Authority"]);
            Assert.IsNotNull(factory.GetToken());
        }
    }
}
