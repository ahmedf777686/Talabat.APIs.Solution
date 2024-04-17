using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public interface ISpecifications<T> where T : BaseEntity    
    {
       // _context.Set<Product>().Where(p=> p.Id == id).Include(b => b.Brand).Include(c => c.Category)

        public Expression<Func<T,bool>> Criterai { get; set; } // p=> p.Id == id

        public List< Expression<Func<T,object>>> Include { get; set; } // Include(b => b.Brand)


    }
}
