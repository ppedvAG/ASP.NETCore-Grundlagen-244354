using Serilog;

namespace HelloLogging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("app.log", rollingInterval: RollingInterval.Day)
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();
            builder.Host.UseSerilog();

            var app = builder.Build();

            Log.Information("Starting up");
            try
            {
                app.MapGet("/", () => "Hello World!");
                app.MapGet("/error", () =>
                {
                    throw new InvalidOperationException("Hello Invalid Operation Exception");
                });

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                Log.Information("Shutting down");
                Log.CloseAndFlush();
            }
        }
    }
}
