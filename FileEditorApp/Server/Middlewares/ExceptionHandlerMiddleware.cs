using FileEditorApp.Server.Services;
using FileEditorApp.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FileEditorApp.Server.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errorCode = "error";
            var errorType = "internal";
            var statusCode = HttpStatusCode.BadRequest;
            var exceptionType = exception.GetType();
            switch (exception)
            {
                case Exception e when exceptionType == typeof(UnauthorizedAccessException):
                    statusCode = HttpStatusCode.Unauthorized;
                    errorType = "security";
                    break;

                case ServiceException e when exceptionType == typeof(ServiceException):
                    statusCode = HttpStatusCode.BadRequest;
                    errorCode = e.Code;
                    errorType = "service";
                    break;
                
                case DomainException e when exceptionType == typeof(DomainException):
                    statusCode = HttpStatusCode.BadRequest;
                    errorCode = e.Code;
                    errorType = "domain";
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    throw exception;
                    //break;
            }
            var response = new { code = errorCode, errorType };
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(payload);
        }

    }
}
