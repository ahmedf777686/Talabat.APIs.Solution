using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Repositories
{
    public interface IGenericRepository<T> where T :BaseEntity
    {
        // Get All
      public  Task<IEnumerable<T>> GetAllAsync(); 



        // Get By Id
       public Task<T?> GetByIdAsync(int id);
    }
}
