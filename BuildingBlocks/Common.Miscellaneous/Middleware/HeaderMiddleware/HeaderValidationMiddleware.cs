using Common.Miscellaneous.Models;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace Common.Miscellaneous.Middleware.HeaderMiddleware
{
    public class HeaderValidationMiddleware
    {
        private readonly RequestDelegate next;

        private readonly ILogger<RequestDelegate> logger;
        public HeaderValidationMiddleware(RequestDelegate next, ILogger<RequestDelegate> logger)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {

                //string? token = httpContext.Request.Headers["subprogramcode"];
                //if (token == null && !(httpContext.Request.Path.Value?.ToLower().Contains("token") ?? false))
                //{
                //    httpContext.Response.ContentType = "application/json";
                //    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                //    await httpContext.Response.WriteAsync(new ErrorDetails()
                //    {
                //        ResponseCode = ResponseCodes.SubProgramCodeisblank,
                //        //Message = "Please provide Sub Program Code in Header!"
                //    }.ToJSON());
                //    return;
                //}

                await next(httpContext);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string? errorCode = string.Empty;
            context.Response.ContentType = "application/json";
            var statusCode = exception switch
            {
                ValidationException => (int)HttpStatusCode.BadRequest,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.InternalServerError
            };
            context.Response.StatusCode = statusCode;

            string? errorMessage = exception switch
            {
                { Message: var message } when message.Contains("ResponseCode") => HandleBadReqestException(exception, message,  out errorCode),
                { Source: var source } when source.Contains("Application") => HandleApplicationException(exception, statusCode, out errorCode),

                { Source: var source } when source.Contains("Microsoft.EntityFrameworkCore") => HandleCoreLibException(exception, ref statusCode, out errorCode),
                { Source: var source } when source.Contains("System.Private.CoreLib") => HandleCoreLibException(exception, ref statusCode, out errorCode),

                _ => HandleOtherException(exception, out errorCode)
            };

            if (!string.IsNullOrEmpty(errorMessage) && errorMessage.Contains("ResponseCode"))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(exception.Message);

            }
            else if (statusCode == (int)HttpStatusCode.InternalServerError)
            {
                await context.Response.WriteAsync(new InternalServerErrorDetails()
                {
                    ResponseCode = Convert.ToInt32(errorCode),
                    Message = errorMessage
                }.ToString());
            }
            else if (string.IsNullOrWhiteSpace(errorCode))
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(exception.Message);
            }
            else
            {
                await context.Response.WriteAsync(new ErrorDetails()
                {

                    ResponseCode = Convert.ToInt32(errorCode),
                }.ToString());
            }
        }

        static string? HandleApplicationException(Exception exception, int statusCode, out string errorCode)
        {
            var errors = ((ValidationException)exception).Errors;
            errorCode = errors?.FirstOrDefault()?.ErrorCode;
            return statusCode == (int)HttpStatusCode.InternalServerError ? errors?.FirstOrDefault()?.ErrorMessage : null;
        }

        static string? HandleBadReqestException(Exception exception, string message, out string? errorCode)
        {

            errorCode = HttpStatusCode.BadRequest.ToString();
            return message = exception.Message;
        }
        string HandleCoreLibException(Exception exception, ref int statusCode, out string? errorCode)
        {
           
            logger.LogError($"ValidationException exception : {JsonConvert.SerializeObject(exception)}");
            errorCode = null;
            statusCode = (int)HttpStatusCode.BadRequest;
            return exception.Message;
        }
        string HandleOtherException(Exception exception, out string? errorCode)
        {
            
            logger.LogError($"ValidationException exception : {JsonConvert.SerializeObject(exception)}");
            errorCode = null;
            return exception.Message;
        }

    }
}
