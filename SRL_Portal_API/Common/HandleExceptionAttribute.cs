using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http.Filters;
using Newtonsoft.Json;
using SRL.Models.Exceptions;

namespace SRL_Portal_API.Common
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception == null) return;

            var exception = actionExecutedContext.Exception;

            HttpResponseMessage response;
            if (exception.GetType() == typeof(HttpMessageException))
            {
                var ex = (HttpMessageException)actionExecutedContext.Exception;
                response = new HttpResponseMessage
                {
                    StatusCode = ex.Status,
                    ReasonPhrase = Regex.Replace(exception.Message, @"\r\n?|\n", " "),
                    Content = new StringContent(JsonConvert.SerializeObject(ex.Response))
                };
            }
            else
            {
                response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = Regex.Replace(exception.Message, @"\r\n?|\n", " ")
                };
            }

            actionExecutedContext.Response = response;
            AddLogEntry(actionExecutedContext.Request, exception, actionExecutedContext.ActionContext.RequestContext.Principal.Identity.Name);
        }

        private static void AddLogEntry(HttpRequestMessage message, System.Exception exception, string currentUser)
        {
            var log = log4net.LogManager.GetLogger("EuropoolSystemPortal");

            log.ErrorFormat(
                $"Exception: {exception.Message} occurred during the request {message.Method}{message.RequestUri} made by user {currentUser}: Stack trace:{exception.StackTrace}");
        }

    }
}