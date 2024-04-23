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

        public ProductWithBrandAndCategorySpecification(string sort)
            :base()
        {
            AddInclude();

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {

                    case "priceAsc":
                        AddOrderBy(o => o.Price);
                        break;
                    case "priceDesc":
                        AddAddOrderByDesc(o => o.Price);
                        break;
                    default:
                        AddOrderBy(o => o.Name);

                        break;
                }
            }
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
