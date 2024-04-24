using Talabat.Core.Entities;
using Talabat.Core.Specifications;
using Talabat.Core.Specifications.ProductSpecification;

namespace Talabat.APIs.Helpers
{
    public class productCountSpec :Basespecification<Product>
    {



        public productCountSpec(ProductspecParams Params)
            : base(e => (string.IsNullOrEmpty(Params.Search) || e.Name.ToLower().Contains(Params.Search)) && (!Params.BrandId.HasValue || e.BrandId == Params.BrandId) && (!Params.CategoryId.HasValue || e.CategoryId == Params.CategoryId))
        {
           


        }
    }
}
