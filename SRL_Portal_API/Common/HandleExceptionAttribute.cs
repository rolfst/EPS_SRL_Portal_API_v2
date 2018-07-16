using System.Net;
using System.Net.Http;
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
                    ReasonPhrase = exception.Message
                };
                actionExecutedContext.Response = response;
            }
        }
    }
}