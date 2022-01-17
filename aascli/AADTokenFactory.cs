using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AAS.CLI
{
    public class AADTokenFactory : TokenFactory
    {
        private string _token;

        private string clientId;
        private string clientSecret;
        private string clientCertificateThumbprint;
        private string authority;
        private string scope;

        public bool ValidateCertificate { get; set; }

        private readonly ILogger _logger;

        public AADTokenFactory(IConfiguration configuration, ILogger<AADTokenFactory> logger)
        {
            clientId = configuration["ClientId"];
            clientSecret = configuration["ClientSecret"];
            authority = configuration["Authority"];
            scope = configuration["Scope"];

            ValidateCertificate = configuration.GetValue<bool>("ValidateClientCertificate");
            clientCertificateThumbprint = configuration["ClientCertificateThumbprint"];

            _logger = logger;
        }

        public AADTokenFactory(string aClientId, string aClientSecret, string anAuthoriy)
        {
            clientId = aClientId;
            clientSecret = aClientSecret;
            authority = anAuthoriy;

            ValidateCertificate = false;
        }

        public string GetToken()
        {
            if (_token == null)
            {
                ConfidentialClientApplicationBuilder appBuilder = ConfidentialClientApplicationBuilder.Create(clientId).WithAuthority(new Uri(authority));

                if (!string.IsNullOrEmpty(clientSecret) && (clientSecret != "Enter here"))
                {
                    appBuilder = appBuilder.WithClientSecret(clientSecret);
                } else
                {
                    //appBuilder.WithCertificate(GetCertByName(StoreLocation.CurrentUser, $"aas-commandline.{clientId}"));

                    appBuilder.WithCertificate(GetCertByThumbprint(StoreLocation.CurrentUser, clientCertificateThumbprint));

                    //appBuilder.WithCertificate(GetCert("Enter your cert file path", "Enter your cert password"));
                }

                IConfidentialClientApplication app = appBuilder.Build();

                _token = app.AcquireTokenForClient(new string[] 
                    { $"api://{scope}/.default" }).ExecuteAsync().GetAwaiter().GetResult().AccessToken;

                if (_logger != null)
                    _logger.LogTrace($"Got token: {_token}");
            }

            return _token;
        }

        /// <summary>
        /// Gets a certificate based on the name -- please note, there is an issue using this method
        /// if there are multiple certs with the same name.
        /// </summary>
        /// <param name="storeLoc"></param>
        /// <param name="subjectName"></param>
        /// <returns></returns>
        private X509Certificate2 GetCertByName(StoreLocation storeLoc, String subjectName)
        {
            // read certificates already installed from the certificate store
            X509Store store = new X509Store(storeLoc);
            X509Certificate2 cer = null;

            store.Open(OpenFlags.ReadOnly);

            // look for the specific cert by subject name -- returns the first one found, if any.  Also, for self signed, set the valid parameter to 'false'
            X509Certificate2Collection cers = store.Certificates.Find(X509FindType.FindBySubjectName, subjectName, ValidateCertificate);
            if (cers.Count > 0)
            {
                cer = cers[0];
            };
            store.Close();

            return cer;
        }

        /// <summary>
        /// Gets a certificate by Thumbprint -- this is the preferred method
        /// </summary>
        /// <param name="storeLoc"></param>
        /// <param name="thumbprint"></param>
        /// <returns></returns>
        private X509Certificate2 GetCertByThumbprint(StoreLocation storeLoc, String thumbprint)
        {
            X509Store store = new X509Store(storeLoc);
            X509Certificate2 cer = null;

            store.Open(OpenFlags.ReadOnly);

            // look for the specific cert by thumbprint -- Also, for self signed, set the valid parameter to 'false'
            X509Certificate2Collection cers = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, ValidateCertificate);
            if (cers.Count > 0)
            {
                cer = cers[0];
            };
            store.Close();

            return cer;
        }

        /// <summary>
        /// Gets a certificate by the .pfx name from the file system
        /// </summary>
        /// <param name="basePath">The folder where the cert is stored -- filename is derived from the settings in this application</param>
        /// <returns></returns>
        private X509Certificate2 GetCert(String certPath, String cert_password)
        {
            X509Certificate2 cer = new X509Certificate2(certPath, cert_password, X509KeyStorageFlags.EphemeralKeySet);

            return cer;
        }
    }
}
