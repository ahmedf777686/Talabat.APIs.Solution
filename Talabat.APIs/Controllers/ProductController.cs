using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Dtos;
using Talabat.APIs.Errors;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;
using Talabat.Core.Specifications.ProductSpecification;

namespace Talabat.APIs.Controllers
{
    
    public class ProductController : BaseApiController 
    {   
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductCategory> _categoryRepo;

        public IMapper _Mapper { get; }
        public IGenericRepository<ProductBrand> _BrandRepo { get; }

        public ProductController(IGenericRepository<Product> productRepo,

            
            IMapper mapper
            ,IGenericRepository<ProductBrand> BrandRepo
            , IGenericRepository<ProductCategory> CategoryRepo

            ) 
        {
            _productRepo = productRepo;
            _Mapper = mapper;
           _BrandRepo = BrandRepo;
            _categoryRepo = CategoryRepo;
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


        [ProducesResponseType(typeof(ProductToReturn),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturn>> GetproductByid(int id)
        {

            ProductWithBrandAndCategorySpecification productWithSpc = new ProductWithBrandAndCategorySpecification(id);

            var Product = await _productRepo.GetByIdWithSpecAsync(productWithSpc);
            var res= _Mapper.Map<Product, ProductToReturn>(Product);
        
           
            if(Product is null)
            {
                return NotFound(new ApiResponse(404));
            }
            else
            {
                return Ok(res);
            }
           
        }


        [HttpGet("Brand")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetAllBrand()
        {

            var Brand =  await  _BrandRepo.GetAllAsync();
            return Ok(Brand);
        }


        [HttpGet("Categories")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetAllCategories()
        {

            var Brand = await _categoryRepo.GetAllAsync();
            return Ok(Brand);
        }

    }


}
