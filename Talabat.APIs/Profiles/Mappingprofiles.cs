using AutoMapper;
using Talabat.APIs.Dtos;
using Talabat.Core.Entities;

namespace Talabat.APIs.Profiles
{
    public class Mappingprofiles:Profile
    {
        public Mappingprofiles()
        {
            CreateMap<Product, ProductToReturn>()
                .ForMember(d =>d.Brand,o => o.MapFrom(d =>d.Brand.Name))
                .ForMember(d =>d.Category,o => o.MapFrom(d =>d.Category.Name));
        }
    }
}
