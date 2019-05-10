using HappyPathApi.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HappyPathApi.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandler(RequestDelegate next)
        {
            // Her vil man typisk også injecte en ILogger for å logge feilen
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Logge feilen
            // _logger.Warn("Error occured...")

            HttpStatusCode httpStatusCode = 0;
            string message = "En feil oppsto.";
            switch (exception)
            {
                case ArgumentException ex:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
                case EntityNotFoundException ex:
                    httpStatusCode = HttpStatusCode.NotFound;
                    message = ex.Message;
                    break;
                case DB2UnavailableException ex:
                    httpStatusCode = HttpStatusCode.BadGateway;
                    message = "En feil oppsto i koblingen mot databasen.";
                    break;
                default:
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;

            return context.Response.WriteAsync(message);
        }
    }
}

