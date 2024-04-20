using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Repository.Data;

namespace Talabat.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Buggycontroller : ControllerBase
    {
        private readonly StoreContext _context;

        public Buggycontroller(StoreContext context)
        {
            _context = context;
        }


        [HttpGet("NotFound")]
        public ActionResult Getnotfound() 
        {
            var products = _context.Set<Product>().Find(100);
            if (products == null)

                return NotFound();

            return Ok(products);
        }
        //reference

        [HttpGet("ServerError")]
        public ActionResult GetReferenceErroe()
        {
            var products = _context.Set<Product>().Find(100);

            products.ToString();

            return Ok(products);
        }


        [HttpGet("BadRequest")]
        public ActionResult GetBadError()
        {
            return BadRequest();
        }


        [HttpGet("BadRequest/{id}")]

        public ActionResult GetvalidationError(int id)
        {
            return Ok();
        }
    }
}
