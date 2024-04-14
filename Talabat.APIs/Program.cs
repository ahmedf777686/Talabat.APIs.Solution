using Microsoft.EntityFrameworkCore;
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

            #endregion

            var app = builder.Build();

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

            // Configure the HTTP request pipeline.
            #region Configure Kestrel Middlewares
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            #endregion




            app.Run();
        }
    }
}
