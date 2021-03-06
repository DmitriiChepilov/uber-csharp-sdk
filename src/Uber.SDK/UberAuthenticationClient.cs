﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Uber.SDK.Interfaces;
using Uber.SDK.Models;

namespace Uber.SDK
{
    public class UberAuthenticationClient : IUberAuthenticationClient
    {
        private readonly string _clientId;
        private readonly string _clientSecret;

        /// <summary>
        /// Initialises a new <see cref="UberAuthenticationClient"/>
        /// </summary>
        /// <param name="clientId">
        /// The client ID, this can be found at https://developer.uber.com/apps/
        /// </param>
        /// <param name="clientSecret">
        /// The client secret, this can be found at https://developer.uber.com/apps/
        /// </param>
        public UberAuthenticationClient(string clientId, string clientSecret)
        {
            if (string.IsNullOrWhiteSpace(clientId)) throw new ArgumentException("Parameter is required", "clientId");
            if (string.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentException("Parameter is required", "clientSecret");

            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        /// <summary>
        /// Generates an Uber OAuth authorization URL based on scopes, state and redirect.
        /// </summary>
        /// <param name="scopes">
        /// The permission scope/s being requested.
        /// </param>
        /// <param name="state">
        /// State which will be passed back to you to prevent tampering.
        /// </param>
        /// <param name="redirectUri">
        /// The URI we will redirect back to after an authorization by the resource owner.
        /// </param>
        /// <returns>
        /// Returns the OAuth authorization URL.
        /// </returns>
        public string GetAuthorizeUrl(List<string> scopes = null, string state = null, string redirectUri = null)
        {
            var authorizeUrl = string.Concat("https://login.uber.com/oauth/authorize?response_type=code&client_id=", _clientId);

            if (scopes != null && scopes.Any())
            {
                authorizeUrl += string.Concat("&scope=", string.Join(" ", scopes));
            }

            if (!string.IsNullOrWhiteSpace(state))
            {
                authorizeUrl += string.Concat("&state=", state);
            }

            if (!string.IsNullOrWhiteSpace(redirectUri))
            {
                authorizeUrl += string.Concat("&redirect_uri=", WebUtility.UrlEncode(redirectUri));
            }

            return authorizeUrl;
        }

        /// <summary>
        /// Exchange this authorization code for an AccessToken, allowing requests to be mande on behalf of a user.
        /// </summary>
        /// <param name="authorizationCode">
        /// The authorization code.
        /// </param>
        /// <param name="redirectUri">
        /// The URL the user should be redrected back to 
        /// </param>
        /// <returns>
        /// Returns the <see cref="AccessToken"/>.
        /// </returns>
        public async Task<AccessToken> GetAccessTokenAsync(string authorizationCode, string redirectUri)
        {
            var data = new Dictionary<string, string>
            {
                { "client_id", _clientId },
                { "client_secret", _clientSecret },
                { "grant_type", "authorization_code" },
                { "code", authorizationCode },
                { "redirect_uri", redirectUri }
            };

            return await AuthorizeAsync(data);
        }

		public async Task<AccessToken> GetDelivetyTokenAsync()
		{
			var data = new Dictionary<string, string>
			{
				{ "client_id", _clientId },
				{ "client_secret", _clientSecret },
				{ "grant_type", "client_credentials" },
				{ "scope", "delivery" }
			};

			return await AuthorizeAsync(data);
		}

        /// <summary>
        /// Exchange this authorization code for an AccessToken, allowing requests to be mande on behalf of a user.
        /// </summary>
        /// <param name="refreshToken">
        /// The refresh token.
        /// </param>
        /// <param name="redirectUri">
        /// The URL the user should be redrected back to 
        /// </param>
        /// <returns>
        /// Returns an <see cref="AccessToken"/>.
        /// </returns>
        public async Task<AccessToken> RefreshAccessTokenAsync(string refreshToken, string redirectUri)
        {
            var data = new Dictionary<string, string>
			{
				{ "client_id", _clientId },
				{ "client_secret", _clientSecret },
				{ "grant_type", "refresh_token" },
				{ "refresh_token", refreshToken },
				{ "redirect_uri", redirectUri }
			};

            return await AuthorizeAsync(data);
        }

        /// <summary>
        /// Authorizes a client with Uber OAuth
        /// </summary>
        /// <param name="content">
        /// The HTTP request content
        /// </param>
        /// <returns>
        /// Returns the <see cref="AccessToken"/> if authorization is successful
        /// Returns null if authorization is not successful
        /// </returns>
        private async Task<AccessToken> AuthorizeAsync(Dictionary<string, string> content)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient
                    .PostAsync("https://login.uber.com/oauth/token", new FormUrlEncodedContent(content))
                    .ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var responseContent = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<AccessToken>(responseContent);
            }
        }

        /// <summary>
        /// Revoke a user's access to the Uber API via the application.
        /// </summary>
        /// <param name="accessToken">
        /// The access token being revoked.
        /// </param>
        /// <returns>
        /// Returns a boolean indicating if the Uber API returned a successful HTTP status.
        /// </returns>
        public async Task<bool> RevokeAccessTokenAsync(string accessToken)
        {
            var formData = new Dictionary<string, string>
			{
				{ "client_id", _clientId },
				{ "client_secret", _clientSecret },
				{ "token", accessToken }
			};

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient
                    .PostAsync("https://login.uber.com/oauth/revoke", new FormUrlEncodedContent(formData))
                    .ConfigureAwait(false);

                return response.IsSuccessStatusCode;
            }
        }
    }
}
