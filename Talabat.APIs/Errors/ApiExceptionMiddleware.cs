namespace Talabat.APIs.Errors
{
    public class ApiExceptionMiddleware : ApiResponse
    {

        public string? Details { get; set; }

        public ApiExceptionMiddleware(int statusCoede, string? message = null ,string? details = null) : base(statusCoede, message)
        {
            Details = details;
        }

    }
}
