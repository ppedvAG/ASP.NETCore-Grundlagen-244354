using LabCultureMiddleware.Middlewares;

namespace LabCultureMiddleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.UseRequestCultureMiddleware();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
