namespace LabIoC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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
