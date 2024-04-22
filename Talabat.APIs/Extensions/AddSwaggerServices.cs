namespace Talabat.APIs.Extensions
{
    public static class AddSwaggerServices
    {

        public static IServiceCollection SwaggerServicesExtension(this IServiceCollection services)
        {

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

    }
}
