using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Core.Repositories
{
    public interface IGenericRepository<T> where T :BaseEntity
    {
        // Get All
      public  Task<IEnumerable<T>> GetAllAsync(); 

            

        // Get By Id
       public Task<T?> GetByIdAsync(int id);



        public Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> specifications);



        // Get By Id
        public Task<T?> GetByIdWithSpecAsync(ISpecifications<T> specifications);


        public Task<int> GetProductWithSpecCount(ISpecifications<T> specifications);

    }
}
