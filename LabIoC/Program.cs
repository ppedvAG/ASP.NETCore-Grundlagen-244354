using Lab002_DependencyInjection.Services;

namespace LabIoC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IOperationSingleton, OperationService>();
            builder.Services.AddScoped<IOperationScoped, OperationService>();
            builder.Services.AddTransient<IOperationTransient, OperationService>();

            // Asp.Net sucht nach allen Klassen im Verzeichnis Controllers welche mit dem Suffix Controller aufhoeren
            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Test}");

            app.Run();
        }
    }
}
