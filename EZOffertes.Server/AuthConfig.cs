using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server
{
    public class AuthConfig
    {
        private readonly string _instance;
        private readonly string _tenantId;
        private readonly string _clientId;
        private readonly string _clientSecret;
//        private readonly string _baseAddress;
        private readonly string _resourceId;

        public string Instance { get { return _instance; } }
        public string TenantId { get { return _tenantId; } }
        public string ClientId { get { return _clientId; } }
        public string ClientSecret { get { return _clientSecret; } }
//        public string BaseAddress { get { return _baseAddress; } }
        public string ResourceId { get { return _resourceId; } }
        public string Authority
        {
            get { return string.Format(CultureInfo.InvariantCulture, _instance, _tenantId); }
        }

        public AuthConfig(IConfiguration configuration)
        {
            _instance = configuration.GetSection("AzureAd")["Instance"];
            _tenantId = configuration.GetSection("AzureAd")["TenantId"];
            _clientId = configuration.GetSection("AzureAd")["ClientId"];
            _clientSecret = configuration.GetSection("AzureAd")["ClientSecret"];
            //_baseAddress = configuration.GetSection("AzureAd")["BaseAddress"];
            _resourceId = configuration.GetSection("AzureAd")["ResourceId"];
        }

        public string GetBearerToken()
        {
            IConfidentialClientApplication app;
            app = ConfidentialClientApplicationBuilder.Create(_clientId)
                .WithClientSecret(_clientSecret)
                .WithAuthority(new Uri(Authority))
                .Build();
            string[] ResourceIDs = new string[] { _resourceId };

            try
            {
                AuthenticationResult authResult = app.AcquireTokenForClient(ResourceIDs).ExecuteAsync().Result;
                return authResult.AccessToken;
            }
            catch (MsalClientException)
            {
                throw;
            }
        }


    }
}
