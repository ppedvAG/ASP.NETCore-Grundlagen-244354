using HelloIoC.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HelloIoC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = RegisterTypes();

            //var service = serviceProvider.GetService<ITimeService>();
            //Console.WriteLine(service.GetTime());

            var awesomeService = serviceProvider.GetService<IAwesomeService>();
            awesomeService.DoSomething();

            Console.ReadKey();
        }

        private static ServiceProvider RegisterTypes()
        {
            var container = new ServiceCollection();

            // Wir registrieren die konkrete Implementierung des Service gegen das Interface ITimeService
            container.AddTransient<ITimeService, CurrentTimeService>();

            // Hier wird die vorherige Registierung mit einer anderen Implementierung ersetzt
            container.AddTransient<ITimeService, UniversalTimeService>();

            // Service als Factory registrieren
            container.AddTransient<ITimeService>(c => new CustomTimeService("Als Factory registriert"));

            container.AddTransient<IAwesomeService, AwesomeService>();

            var serviceProvider = container.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
