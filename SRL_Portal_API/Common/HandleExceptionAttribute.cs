using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using log4net;

namespace SRL_Portal_API.Common
{
    
    /// <summary>
    /// Class to handle global exception
    /// </summary>
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {

        
        /// <summary>
        /// Override the OnExcpetion method to implement custom exception handling
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
              
            if (actionExecutedContext.Exception != null)
            {
                var exception = actionExecutedContext.Exception;
                var response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = exception.Message
                };
                actionExecutedContext.Response = response;
                AddLogEntry(actionExecutedContext.Request, exception, actionExecutedContext.ActionContext.RequestContext.Principal.Identity.Name);
            }
        }

        private void AddLogEntry(HttpRequestMessage message, System.Exception exception, string currentUser)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("ErrorLogger");

            log.ErrorFormat(string.Format("Exception: {0} occurred during the request {1}{2} made by user {3}: Stack trace:{4}",exception.Message, message.Method,message.RequestUri, currentUser,exception.StackTrace));
        }
    }

}