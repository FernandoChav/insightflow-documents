using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsightFlow.Documents.Api.Core.Middlewares
{
    public class ErrorHandlerMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ApiResponse<string>() { Succeeded = false, Message = error?.Message };

                response.StatusCode = error switch
                {
                    KeyNotFoundException e => (int)HttpStatusCode.NotFound,// Excepción personalizada para 404
                    ArgumentException e => (int)HttpStatusCode.BadRequest,// Excepción para validaciones (400)
                    _ => (int)HttpStatusCode.InternalServerError,// Error no controlado (500)
                };
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}