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

        public ProductWithBrandAndCategorySpecification()
            :base()
        {
            AddInclude();
        }

      

        public ProductWithBrandAndCategorySpecification(int id)
            :base(p => p.Id == id)
        {


            AddInclude();
        }

        private void AddInclude()
        {
            base.Include.Add(p => p.Brand);
            base.Include.Add(p => p.Category);
        }
    }
}
