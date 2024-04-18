using AutoMapper;
using Talabat.APIs.Dtos;
using Talabat.Core.Entities;

namespace Talabat.APIs.Helpers
{
    public class Productpictureurlresolve : IValueResolver<Product, ProductToReturn, string>
    {
        public IConfiguration _Configuration { get; }
        public Productpictureurlresolve(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        

        public string Resolve(Product source, ProductToReturn destination, string destMember, ResolutionContext context)
        {

            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{"https://localhost:7026"}/{source.PictureUrl}";

            return string.Empty;
        }
    }
}
