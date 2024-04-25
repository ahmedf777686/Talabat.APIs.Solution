using StackExchange.Redis;
using System.Text.Json;
using Talabat.Core.Entities.Basket;
using Talabat.Core.Repositories;

namespace Talabat.Repository
{
    public class BasketRepository : IBasketRepository
    {

        private IDatabase _database { get ; set; }
        public BasketRepository(IConnectionMultiplexer Redis)
        {
            _database = Redis.GetDatabase();
        }

       

        public async Task<bool> DeleteBasket(string id)
        {
            var res = await _database.KeyDeleteAsync(id);
            return res;
        }



        public async Task<CustomerBasket?> GetBasket(string id)
        {
            var Basket = await _database.StringGetAsync(id);
          
          // var Result = JsonSerializer.Deserialize< CustomerBasket >(Basket);
            return Basket.IsNull ? null :JsonSerializer.Deserialize<CustomerBasket>(Basket);
        }


        public async Task<CustomerBasket?> UpdateOrCreateBasket(CustomerBasket basket)
        {
            var JsonBasket = JsonSerializer.Serialize(basket);
          var CreateOrUdate=  await _database.StringSetAsync(basket.Id, JsonBasket, TimeSpan.FromDays(3)) ;

            if (!CreateOrUdate) return null;
           


            return await GetBasket(basket.Id);



        }
    }
}

