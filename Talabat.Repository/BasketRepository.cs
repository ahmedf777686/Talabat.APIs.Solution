using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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
            return await _database.KeyDeleteAsync(id);
        }

        public async Task<CustomerBasket?> GetBasket(string id)
        {
            var Basket = await _database.StringGetAsync(id);
          
            return  Basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(Basket);
        }

        public async Task<CustomerBasket> UpdateOrCreateBasket(CustomerBasket basket)
        {
          var CreateOrUdate=  await _database.StringSetAsync(basket.Id,JsonSerializer.Serialize(basket),TimeSpan.FromDays(3)) ;

            if (!CreateOrUdate) return null;
            else
            return await GetBasket(basket.Id);



        }
    }
}

