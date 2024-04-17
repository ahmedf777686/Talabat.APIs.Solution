using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Repository
{
    public static class SpecificationEvaluator<T> where T: BaseEntity
    {

        public static IQueryable<T> GetQuery(IQueryable<T> InuputQuery ,ISpecifications<T> specifications)
        {
            var Query = InuputQuery;

            if(specifications.Criterai != null)
            {
                Query = Query.Where(specifications.Criterai);
            }

            Query = specifications.Include.Aggregate(Query, (CurrentQuery, IncludeInput) => CurrentQuery.Include(IncludeInput));
            return Query;
        }
    }
}
