using System;
using System.Net;
using System.Text;

namespace SRL.Models.Exceptions
{
    public class HttpMessageException : Exception
    {
        public HttpMessage Response { get; set; }
        public HttpStatusCode Status { get; set; }

        public HttpMessageException(HttpStatusCode status, HttpMessage response, string message) : base(message)
        {
            Status = status;
            Response = response;
        }
    }

    public enum HttpMessageType
    {
        Info = 1,
        Warn = 2,
        Error = 3
    }
    public static class HttpMessageExceptionBuilder
    {
        /// <summary>
        /// Create a <see cref="HttpMessageException"/> based on the http status.
        /// </summary>
        /// <param name="status">The status code which throws the warning</param>
        /// <param name="response">The original response, in Json</param>
        /// <param name="addition">The addition to the message. </param>
        /// <returns>a throwable <see cref="HttpMessageException"/></returns>
        public static HttpMessageException Build(HttpStatusCode status, HttpMessageType type, string response, string responseLocation, string addition = "")
        {
            string statusMessage; 
            switch (status)
            {
                case HttpStatusCode.Ambiguous:
                    statusMessage = string.Format(WarningMessages.Ambiguous, responseLocation, addition);
                    break;
                case HttpStatusCode.NoContent:
                    statusMessage = string.Format(WarningMessages.NoContent, responseLocation, addition);
                    break;
                case HttpStatusCode.NotFound:
                    statusMessage = string.Format(WarningMessages.NotFound, responseLocation, addition);
                    break;
                case HttpStatusCode.Accepted:
                    statusMessage = string.Format(WarningMessages.Accepted, responseLocation, addition);
                    break;
                case HttpStatusCode.Conflict:
                    statusMessage = string.Format(WarningMessages.Conflict, responseLocation, addition);
                    break;
                default:
                    statusMessage = string.Format(WarningMessages.Generic, responseLocation, addition);
                    break;
            }

            var message = BuildResponseString(type, statusMessage, response);
            return new HttpMessageException(status, message, statusMessage);
        }

        private static HttpMessage BuildResponseString(HttpMessageType type, string msg, string response)
        {
            var typeString = type.ToString();
            var message = msg;
            var body = response;


            return new HttpMessage { Body = body, Message = message, Type = typeString };
        }
    }
}
