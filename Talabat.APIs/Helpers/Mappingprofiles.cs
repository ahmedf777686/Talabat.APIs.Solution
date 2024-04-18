using AutoMapper;
using Talabat.APIs.Dtos;
using Talabat.APIs.Helpers;
using Talabat.Core.Entities;
using static System.Net.WebRequestMethods;

namespace Talabat.APIs.Helpers
{
    public class Mappingprofiles:Profile
    {
        public Mappingprofiles(IConfiguration configuration)
        {
            _Configuration = configuration;
            CreateMap<Product, ProductToReturn>()
                .ForMember(d => d.Brand, o => o.MapFrom(d => d.Brand.Name))
                .ForMember(d => d.Category, o => o.MapFrom(d => d.Category.Name))
                //.ForMember(d=>d.PictureUrl,o =>o.MapFrom());

               .ForMember(d => d.PictureUrl,o => o.MapFrom(d => $"{_Configuration["ApiBaseUrl"]}/{d.PictureUrl}"));
            
        }

       public IConfiguration _Configuration { get; }
    }
}
