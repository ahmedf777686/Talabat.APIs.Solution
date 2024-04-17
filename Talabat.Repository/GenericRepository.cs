using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if(typeof(T) == typeof(Product))
            {
                  return (IEnumerable<T>) await  _context.Set<Product>().Include(b => b.Brand).Include(c => c.Category).ToListAsync();
            }
            else
            {
                return await _context.Set<T>().ToListAsync();
            }
          
        }

    

        public async Task<T?> GetByIdAsync(int id)
        {
            if (typeof(T) == typeof(Product))
             return await _context.Set<Product>().Where(p=> p.Id == id).Include(b => b.Brand).Include(c => c.Category).FirstAsync() as T;

            
          return await _context.Set<T>().Where(p => p.Id == id).FirstAsync();
        }



        public async Task<T?> GetByIdWithSpecAsync(ISpecifications<T> specifications)
        {
            return  await SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), specifications).FirstOrDefaultAsync();
        }
        public async  Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> specifications)
        {
            return await SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), specifications).ToListAsync();
        }
    }
}
