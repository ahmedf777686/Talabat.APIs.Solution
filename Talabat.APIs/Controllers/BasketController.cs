using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Dtos;
using Talabat.APIs.Errors;
using Talabat.Core.Entities.Basket;
using Talabat.Core.Repositories;

namespace Talabat.APIs.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository,IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string id)
        {
           var Basket = await _basketRepository.GetBasket(id);
            if(Basket is null)
            {
                return Ok(new CustomerBasket(id));
            }
            else
            {
                return Ok(Basket);
            }
        }




        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {

            var res = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
            var Bas =  await _basketRepository.UpdateOrCreateBasket(res);
            if (Bas is null)
                return BadRequest(new ApiResponse(400));
            else
                return  Ok(Bas);

        }


        [HttpDelete]
        public  async Task<ActionResult<bool>> DeleteBasket(string id)
        {
            var Result = await _basketRepository.DeleteBasket(id);
            return Result;
        }
        
    }
}
