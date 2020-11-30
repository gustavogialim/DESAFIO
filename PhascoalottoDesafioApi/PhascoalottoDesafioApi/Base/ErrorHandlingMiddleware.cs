using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PhascoalottoDesafio.Infraestrutura.Transversal;
using PhascoalottoDesafio.Infraestrutura.Transversal.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PhascoalottoDesafioApi.Base
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Error error;

            int statusCode;
            if (exception is AppException)
            {
                var appException = exception as AppException;
                error = new Error(appException.Message);
                statusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                error = new Error(exception.GetLastInnerException());
                statusCode = (int)HttpStatusCode.InternalServerError;
            }

            var serializerSettings = new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver() };
            var result = JsonConvert.SerializeObject(error, serializerSettings);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
