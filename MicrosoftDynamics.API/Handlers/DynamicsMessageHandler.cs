using Microsoft.IdentityModel.Clients.ActiveDirectory;
using MicrosoftDynamics.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicrosoftDynamics.API.Handlers
{
    public class DynamicsMessageHandler : DelegatingHandler
    {
        public AuthenticationHeader AuthenticationHeader { get; set; }
        private AuthenticationHeaderValue _authHeader;
        private string _serviceUrl;
        private string _clientId;
        private string _clientSecret;
        private string _redirectUrl;

        public DynamicsMessageHandler(string serviceUrl, string clientId, string clientSecret, string redirectUrl)
            : base(new HttpClientHandler())
        {
            _serviceUrl = serviceUrl;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _redirectUrl = redirectUrl;
            Authenticate().Wait();
        }
        public DynamicsMessageHandler(AuthenticationHeader authenticationHeader)
            : base(new HttpClientHandler())
        {
            _authHeader = new AuthenticationHeaderValue(authenticationHeader.Scheme, authenticationHeader.Parameter);
        }

        private async Task Authenticate()
        {
            AuthenticationParameters authenticationParameters = await AuthenticationParameters.CreateFromUrlAsync(new Uri(_serviceUrl + "api/data/"));
            AuthenticationContext authContext = new AuthenticationContext(authenticationParameters.Authority, false);
            AuthenticationResult authResult = authContext.AcquireTokenAsync(_serviceUrl, _clientId, new Uri(_redirectUrl), new PlatformParameters(PromptBehavior.Auto)).Result;

            _authHeader = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
            AuthenticationHeader = new AuthenticationHeader { Scheme = _authHeader.Scheme, Parameter = _authHeader.Parameter };
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = _authHeader;
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
