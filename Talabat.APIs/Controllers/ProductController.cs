using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;
using Talabat.Core.Specifications.ProductSpecification;

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
            ProductWithBrandAndCategorySpecification productWithSpc = new ProductWithBrandAndCategorySpecification();

             var Result = await _productRepo.GetAllWithSpecAsync(productWithSpc);

            return Ok(Result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetproductByid(int id)
        {

            ProductWithBrandAndCategorySpecification productWithSpc = new ProductWithBrandAndCategorySpecification(p =>p.Id == id);

            var Product = await _productRepo.GetByIdWithSpecAsync(productWithSpc);

            if(Product is null)
            {
                return NotFound(new {Message = "NotFound" });
            }
            else
            {
                return Ok(Product);
            }
           
        }
    }
}
