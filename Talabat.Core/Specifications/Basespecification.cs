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
        public Expression<Func<T, bool>> Criterai { get ; set ; } // Where(p=> p.Id == id)
        public List<Expression<Func<T, object>>> Include { get ; set ; } // Include(b => b.Brand).Include(c => c.Category)

        // using Get all
        public Basespecification()
        {
            Include = new List<Expression<Func<T, object>>> ();
        }

         // Get By Id
        public Basespecification(Expression<Func<T, bool>> ExpressionCriterai)
        {
            Criterai = ExpressionCriterai;
            Include = new List<Expression<Func<T, object>>>();

        }
    }
}
