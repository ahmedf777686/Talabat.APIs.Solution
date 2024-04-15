using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;

namespace Talabat.APIs.Controllers
{
    
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;

        public ProductController(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        // [baseUrl/Api/product] + Get
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct()
        {
             var Result = await _productRepo.GetAllAsync();
            return Ok(Result);
        }

    }
}
