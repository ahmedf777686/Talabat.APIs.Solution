using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Errors;

namespace Talabat.APIs.Controllers
{
    [Route("Error/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorController : ControllerBase
    {

        public ActionResult Error(int code)
        {
          
            if(code == 401)
            {
                return Unauthorized(new ApiResponse(401));
            }
            else
            {
                return NotFound(new ApiResponse(404));

            }


        }
    }
}
