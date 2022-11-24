using Microsoft.EntityFrameworkCore;
using OEC222.Pizzeria.Core.BusinessLogic;
using OEC222.Pizzeria.Core.EF;
using OEC222.Pizzeria.Core.EF.Repositories;
using OEC222.Pizzeria.Core.Interfaces;
using OEC222.Pizzeria.Core.Mock.Repositories;
using OEC222.Pizzeria.Core.Mock.Storages;

namespace OEC222.Pizzeria.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            
            builder.Services.AddScoped<IMainBusinessLogic, MainBusinessLogic>();
            builder.Services.AddScoped<IPizzaRepository, EFPizzaRepository>();
            builder.Services.AddScoped<IIngredientRepository, EFIngredientRepository>();
            builder.Services.AddScoped<ICompositionRepository, EFCompositionRepository>();
            builder.Services.AddDbContext<PizzeriaDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}