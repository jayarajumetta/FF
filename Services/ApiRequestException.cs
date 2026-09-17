#nullable enable
using System;
using System.Net;

namespace PnCTestAutomation.Services
{
    public sealed class ApiRequestException : Exception
    {
        public ApiRequestException(
            string message,
            HttpStatusCode? statusCode = null,
            Exception? innerException = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode? StatusCode { get; }
    }

    public sealed class AuthenticationFlowException : Exception
    {
        public AuthenticationFlowException(
            string message,
            HttpStatusCode? statusCode = null,
            Exception? innerException = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode? StatusCode { get; }
    }
}
