using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public class Basespecification<T> : ISpecifications<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criterai { get; set; } = null!; // Where(p=> p.Id == id)
        public List<Expression<Func<T, object>>> Include { get ; set ; }   = new List<Expression<Func<T, object>>>(); // Include(b => b.Brand).Include(c => c.Category)

        // using Get all
        public Basespecification()
        {
            //Criterai = null 
        }

         // Get By Id
        public Basespecification(Expression<Func<T, bool>> ExpressionCriterai)
        {
            Criterai = ExpressionCriterai;
            

        }
    }
}
