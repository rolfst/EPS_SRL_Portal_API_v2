using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SRL.Models;

namespace SRL.Data_Access.Repository
{
    public class ActiveDirectoryRepository
    {
        private static string aadInstance = "https://login.microsoftonline.com/";
        private static string aadGraphResourceId = "https://graph.windows.net/";
        private static string aadGraphEndpoint = "https://graph.windows.net/";
        private static string aadGraphSuffix = "";
        private const string AadGraphVersion = "api-version=1.6";

        private static readonly string tenant = ConfigurationManager.AppSettings["b2c:Tenant"];
        private static readonly string clientId = ConfigurationManager.AppSettings["b2c:ClientId"];
        private static readonly string clientSecret = ConfigurationManager.AppSettings["b2c:ClientSecret"];

        private readonly AuthenticationContext authContext;
        private readonly ClientCredential credential;

        public ActiveDirectoryRepository()
        {
            // The AuthenticationContext is ADAL's primary class, in which you indicate the directory to use.
            authContext = new AuthenticationContext("https://login.microsoftonline.com/" + tenant);

            // The ClientCredential is where you pass in your client_id and client_secret, which are 
            // provided to Azure AD in order to receive an access_token using the app's identity.
            credential = new ClientCredential(clientId, clientSecret);
        }

        public IEnumerable<User> SynchronizeUsers()
        {
            var result = SendGraphGetRequest("/users", null);

            return result;
        }

        public IEnumerable<User> SendGraphGetRequest(string api, string query)
        {
            // First, use ADAL to acquire a token using the app's identity (the credential)
            // The first parameter is the resource we want an access_token for; in this case, the Graph API.
            var authResult = authContext.AcquireTokenAsync("https://graph.windows.net", credential).Result;

            // For B2C user managment, be sure to use the 1.6 Graph API version.
            var http = new HttpClient();
            var url = $"https://graph.windows.net/{tenant}{api}?{AadGraphVersion}";
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

            return FilterUsers(result);
        }

        private static IEnumerable<User> FilterUsers(string result)
        {
            var substring = result.Substring(result.IndexOf("[", StringComparison.Ordinal));
            substring = substring.Substring(0, substring.LastIndexOf('}'));
            var res = (IEnumerable<object>)JsonConvert.DeserializeObject(substring);

            return (from jsonUser in res
                select JObject.Parse(jsonUser.ToString())
                into data
                let firstName = ((dynamic) data).givenName
                let lastName = ((dynamic) data).surname
                let userName = ((dynamic) data).userPrincipalName
                select new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = userName
                }).ToList();
        }
    }
}
