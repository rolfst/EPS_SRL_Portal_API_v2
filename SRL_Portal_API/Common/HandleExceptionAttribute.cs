using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http.Filters;

namespace SRL_Portal_API.Common
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                var exception = actionExecutedContext.Exception;
                var response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = Regex.Replace(exception.Message, @"\r\n?|\n", " ")
                };
                actionExecutedContext.Response = response;
                AddLogEntry(actionExecutedContext.Request, exception, actionExecutedContext.ActionContext.RequestContext.Principal.Identity.Name);
            }
        }

        private void AddLogEntry(HttpRequestMessage message, System.Exception exception, string currentUser)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("EuropoolSystemPortal");

            log.ErrorFormat(string.Format("Exception: {0} occurred during the request {1}{2} made by user {3}: Stack trace:{4}", exception.Message, message.Method, message.RequestUri, currentUser, exception.StackTrace));
        }

    }
}