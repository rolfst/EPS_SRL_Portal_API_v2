using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SRL.Models;

namespace SRL.Data_Access.Repository
{
    public class ActiveDirectoryUserRepository
    {
        private const string AadInstance = "https://login.microsoftonline.com/";
        private const string AadGraphResourceId = "https://graph.windows.net/";
        private const string AadGraphVersion = "api-version=1.6";

        private static readonly string tenant = ConfigurationManager.AppSettings["b2c:Tenant"];
        private static readonly string clientId = ConfigurationManager.AppSettings["b2c:ClientId"];
        private static readonly string clientSecret = ConfigurationManager.AppSettings["b2c:ClientSecret"];

        private readonly AuthenticationContext authContext;
        private readonly ClientCredential credential;

        public ActiveDirectoryUserRepository()
        {
            // The AuthenticationContext is ADAL's primary class, in which you indicate the directory to use.
            authContext = new AuthenticationContext($"{AadInstance}{tenant}");

            // The ClientCredential is where you pass in your client_id and client_secret, which are 
            // provided to Azure AD in order to receive an access_token using the app's identity.
            credential = new ClientCredential(clientId, clientSecret);
        }

        public IEnumerable<User> GetUsers()
        {
            var users = SendGraphGetRequest("/users", null);
            return FilterUsersFromGraphResult(users);
        }

        public string SendGraphGetRequest(string api, string query)
        {
            // First, use ADAL to acquire a token using the app's identity (the credential)
            // The first parameter is the resource we want an access_token for; in this case, the Graph API.
            var authResult = authContext.AcquireTokenAsync(AadGraphResourceId, credential).Result;

            // For B2C user managment, be sure to use the 1.6 Graph API version.
            var http = new HttpClient();
            var url = $"{AadGraphResourceId}{tenant}{api}?{AadGraphVersion}";
            if (!string.IsNullOrEmpty(query))
            {
                url += $"&{query}";
            }

            // Append the access token for the Graph API to the Authorization header of the request, using the Bearer scheme.
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
            var response = http.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                // Create new exception on calling Graph API.
                var error = response.Content.ReadAsStringAsync().Result;
                var formatted = JsonConvert.DeserializeObject(error);
                throw new WebException("Error Calling the Graph API: \n" + JsonConvert.SerializeObject(formatted, Formatting.Indented));
            }


            var result = response.Content.ReadAsStringAsync().Result;
            return result;
        }

        private IEnumerable<User> FilterUsersFromGraphResult(string result)
        {
            var substring = result.Substring(result.IndexOf("[", StringComparison.Ordinal));
            substring = substring.Substring(0, substring.LastIndexOf('}'));
            var res = (IEnumerable<object>)JsonConvert.DeserializeObject(substring);

            List<User> list = new List<User>();
            foreach (var jsonUser in res)
            {
                var data = JObject.Parse(jsonUser.ToString());
                dynamic userId = ((dynamic) data).objectId;
                dynamic firstName = ((dynamic) data).givenName;
                dynamic lastName = ((dynamic) data).surname;
                string userName = ((dynamic) data).userPrincipalName;
                bool isInternal = userName.Contains(ConfigurationManager.AppSettings["b2c:InternalUserGroup"]);
                list.Add(new User {FirstName = firstName, LastName = lastName, Email = userName, IsInteranlUser = isInternal});
            }

            return list;
        }
    }
}
