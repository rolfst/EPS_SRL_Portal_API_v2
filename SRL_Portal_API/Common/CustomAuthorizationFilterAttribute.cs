using System;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using SRL.Data_Access.Repository;

namespace SRL_Portal_API.Common
{
    /// <summary>
    /// To handle custom authorization
    /// </summary>
    public class CustomAuthorizationFilterAttribute : System.Web.Http.AuthorizeAttribute
    {
        private string[] RequiredUserRoles { get; set; }

        public CustomAuthorizationFilterAttribute(params string[] requiredUserRoles)
        {
            if (requiredUserRoles.Length == 0)
                throw new ArgumentException("Roles not provided");

            this.RequiredUserRoles = requiredUserRoles;
        }

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            if (actionContext.RequestContext.Principal.Identity.IsAuthenticated)
            {
                if (actionContext.Request.Headers.GetValues("Authorization") != null)
                {
                    // get value from header
                    string authenticationToken = Convert.ToString(
                      actionContext.Request.Headers.GetValues("Authorization").FirstOrDefault()).Replace("Bearer", "").Trim();

                    if (!string.IsNullOrEmpty(authenticationToken))
                    {
                        UserRepository repository = new UserRepository();
                        if (repository.IsUserInRole(actionContext.RequestContext.Principal.Identity.Name, this.RequiredUserRoles))
                        {
                            HttpContext.Current.Response.AddHeader("authenticationToken", authenticationToken);
                            HttpContext.Current.Response.AddHeader("AuthenticationStatus", "Authorized");
                            return;
                        }
                        else
                        {
                            HttpContext.Current.Response.AddHeader("authenticationToken", authenticationToken);
                            HttpContext.Current.Response.AddHeader("AuthenticationStatus", "NotAuthorized");
                            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                            return;
                        }
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    actionContext.Response.ReasonPhrase = "Please provide valid inputs";
                    return;
                }
            }
            else
            {
                HttpContext.Current.Response.AddHeader("AuthenticationStatus", "NotAuthenticated");
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                return;
            }
        }

    
    }
}