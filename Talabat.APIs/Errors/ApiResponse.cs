

namespace Talabat.APIs.Errors
{
    public class ApiResponse
    {

        public int StatusCoede { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int statusCoede , string? message = null) { 

           StatusCoede = statusCoede;
           Message = message ?? GetDefaultMessage(StatusCoede);
        }


        private string? GetDefaultMessage(int statusCoede)
        {
            string? NewMessage = "";

            switch (statusCoede)
            {
                case 400:
                    NewMessage = "Bad Request";
                    break;

                case 401:
                    NewMessage = "Unauthorized";
                    break;
                case 404:
                    NewMessage = "Not Found";
                    break;

                case 405:
                    NewMessage = "Method Not Allowed";
                    break;

                default:NewMessage = null;
                    break;
            }

          
            return NewMessage;

        }
    }
}
