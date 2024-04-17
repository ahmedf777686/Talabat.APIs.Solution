using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.ProductSpecification
{
    public class ProductWithBrandAndCategorySpecification:Basespecification<Product>
    {

        public ProductWithBrandAndCategorySpecification():base()
        {
            Include.Add(p => p.Brand);
            Include.Add(p => p.Category);
        }

        public ProductWithBrandAndCategorySpecification(Expression<Func<Product, bool>> ExpressionCriterai):this()
        {
            Criterai = ExpressionCriterai;
          
        }
    }
}
