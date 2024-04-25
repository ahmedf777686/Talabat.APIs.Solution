using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Basket;

namespace Talabat.Core.Repositories
{
    public interface IBasketRepository
    {

        public Task<CustomerBasket?> GetBasket(string id);


        public Task<CustomerBasket?> UpdateOrCreateBasket(CustomerBasket basket);

        public Task<bool> DeleteBasket(string id);

        
    }
}
