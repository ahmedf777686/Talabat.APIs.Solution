using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Dtos;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;
using Talabat.Core.Specifications.ProductSpecification;

namespace Talabat.APIs.Controllers
{
    
    public class ProductController : BaseApiController 
    {   
        private readonly IGenericRepository<Product> _productRepo;
        public IMapper _Mapper { get; }

        public ProductController(IGenericRepository<Product> productRepo,IMapper mapper) 
        {
            _productRepo = productRepo;
            _Mapper = mapper;
        }


        // [baseUrl/Api/product] + Get
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturn>>> GetAllProduct()
        {
            ProductWithBrandAndCategorySpecification productWithSpc = new ProductWithBrandAndCategorySpecification();

             var Result = await _productRepo.GetAllWithSpecAsync(productWithSpc);
         var ProductToReturn =   _Mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturn>>(Result);
            return Ok(ProductToReturn);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturn>> GetproductByid(int id)
        {

            ProductWithBrandAndCategorySpecification productWithSpc = new ProductWithBrandAndCategorySpecification(id);

            var Product = await _productRepo.GetByIdWithSpecAsync(productWithSpc);
            var res = _Mapper.Map<Product, ProductToReturn>(Product);
            if(Product is null)
            {
                return NotFound(new {Message = "NotFound" });
            }
            else
            {
                return Ok(res);
            }
           
        }
    }
}
