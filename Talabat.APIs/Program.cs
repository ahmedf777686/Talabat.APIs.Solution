using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Talabat.APIs.Errors;
using Talabat.APIs.Extensions;
using Talabat.APIs.Helpers;
using Talabat.APIs.Middlewares;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Repository;
using Talabat.Repository.Data;

namespace Talabat.APIs
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Configure Services





            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.SwaggerServicesExtension();


            // OnConfiguring
            builder.Services.AddDbContext<StoreContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings"));
            });

            builder.Services.AddSingleton<IConnectionMultiplexer>(option =>

            {
                var Connection = builder.Configuration.GetConnectionString("Redis")
                return ConnectionMultiplexer.Connect(Connection);
            });

            ///builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            ///builder.Services.AddScoped<IGenericRepository<ProductBrand>, GenericRepository<ProductBrand>>();
            ///builder.Services.AddScoped<IGenericRepository<ProductCategory>, GenericRepository<ProductCategory>>();

            builder.Services.AddAutoMapper(M => M.AddProfile(new Mappingprofiles(builder.Configuration)));

            //ApplicationExtensionServices.AddApplicationServices(builder.Services);

            builder.Services.AddApplicationServices();


            #endregion

            var app = builder.Build();

            #region Update database
            using var Scope = app.Services.CreateScope();
            var services = Scope.ServiceProvider;
            var _Dbcontext = services.GetRequiredService<StoreContext>();
            var loggerfactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                await _Dbcontext.Database.MigrateAsync();
                await StoreDbcontextseeding.Seedasync(_Dbcontext);
            }
            catch (Exception ex)
            {

                var logger = loggerfactory.CreateLogger<Program>();
                logger.LogError("an Error has been occured during apply the migration");
            }

            #endregion


            // Configure the HTTP request pipeline.
            #region Configure Kestrel Middlewares

            app.UseMiddleware<ExceptionMiddleware>();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStatusCodePagesWithRedirects("/Error/{0}");
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();
            #endregion




            app.Run();
        }
    }
}
