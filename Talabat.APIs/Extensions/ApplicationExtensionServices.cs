using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Errors;
using Talabat.APIs.Helpers;
using Talabat.Core.Repositories;
using Talabat.Repository;

namespace Talabat.APIs.Extensions
{
    public static class ApplicationExtensionServices
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            services.AddSingleton(typeof(IBasketRepository), typeof(BasketRepository));


            services.AddControllers();


            // ErrorValidation Handling
            services.Configure<ApiBehaviorOptions>(option =>
            {

                option.InvalidModelStateResponseFactory = Actioncontext =>
                {

                    var Error = Actioncontext.ModelState.Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(p => p.Value.Errors).Select(e => e.ErrorMessage).ToList();

                    var response = new ErrorValidation()
                    {
                        Errors = Error
                    };
                    return new BadRequestObjectResult(response);
                };



            });

            return services;
        }

    }
}
