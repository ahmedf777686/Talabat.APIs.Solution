using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using Talabat.APIs.Errors;

namespace Talabat.APIs.Middlewares
{
    public class ExceptionMiddleware
    {

        public RequestDelegate _Next { get; }
        public ILogger<ExceptionMiddleware> _Logger { get; }
        public IWebHostEnvironment _Env { get; }

        public ExceptionMiddleware(RequestDelegate Next , ILogger<ExceptionMiddleware> logger , IWebHostEnvironment env  )
        {
            _Next = Next;
            _Logger = logger;
            _Env = env;
        }

      

        public async Task InvokeAsync(HttpContext context)
        {


            try
            {
                await _Next.Invoke(context); // go to middleware
            }
            catch (Exception Ex) 
            {

                _Logger.LogError(Ex.Message);

                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                context.Response.ContentType = "Application/json";

                var response = _Env.IsDevelopment() ? new ApiExceptionMiddleware((int)HttpStatusCode.InternalServerError, Ex.Message, Ex.StackTrace.ToString())
                     :
                     new ApiExceptionMiddleware((int)HttpStatusCode.InternalServerError);

                var Option = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
                var json = JsonSerializer.Serialize(response, Option);
                context.Response.WriteAsync(json);
            }

        }
    }
}
