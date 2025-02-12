
using BusinessLogic.Models.Enums;
using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Services;
using System.Text.Json.Serialization;

namespace DemoWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IRecipeServiceAsync, RecipeService>();

            var connectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddSqlServer<DeliveryDbContext>(connectionString);

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter<Difficulty>());
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter<MealType>());
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter<Cuisine>());
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                })
                .AddXmlSerializerFormatters();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
