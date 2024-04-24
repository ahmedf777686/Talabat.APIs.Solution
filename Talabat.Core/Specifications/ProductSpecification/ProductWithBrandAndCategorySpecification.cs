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

        public ProductWithBrandAndCategorySpecification(ProductspecParams Params)
            : base( e =>(string.IsNullOrEmpty(Params.Search) || e.Name.ToLower().Contains(Params.Search))&& (!Params.BrandId.HasValue || e.BrandId == Params.BrandId) && (!Params.CategoryId.HasValue ||e.CategoryId == Params.CategoryId))
        {
            AddInclude();

            if (!string.IsNullOrEmpty(Params.sort))
            {
                switch (Params.sort)
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

            // product = 100
            // page size =10
            // page index = 1
                                               // 10 * 1-1
            ApplyPagination(Params.PageSize *(Params.PageIndex -1), Params.PageSize);
        
        
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
