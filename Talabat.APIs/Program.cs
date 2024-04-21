using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talabat.APIs.Errors;
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
            builder.Services.AddControllers();





            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // OnConfiguring
            builder.Services.AddDbContext<StoreContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings"));
            });



            ///builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            ///builder.Services.AddScoped<IGenericRepository<ProductBrand>, GenericRepository<ProductBrand>>();
            ///builder.Services.AddScoped<IGenericRepository<ProductCategory>, GenericRepository<ProductCategory>>();



            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));



            builder.Services.AddAutoMapper(M => M.AddProfile(new Mappingprofiles(builder.Configuration)));

            // ErrorValidation Handling
            builder.Services.Configure<ApiBehaviorOptions>(option => 
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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();
            #endregion




            app.Run();
        }
    }
}
