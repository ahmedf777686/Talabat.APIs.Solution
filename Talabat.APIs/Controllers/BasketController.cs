using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Errors;
using Talabat.Core.Entities.Basket;
using Talabat.Core.Repositories;

namespace Talabat.APIs.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
          
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
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
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {

            var Bas =  await _basketRepository.UpdateOrCreateBasket(basket);
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
