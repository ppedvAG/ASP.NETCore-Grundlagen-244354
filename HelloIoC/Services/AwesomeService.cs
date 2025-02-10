namespace HelloIoC.Services
{
    public class AwesomeService : IAwesomeService
    {
        private readonly ITimeService timeService;

        public AwesomeService(ITimeService timeService)
        {
            this.timeService = timeService;
        }

        public void DoSomething()
        {
            Console.WriteLine("Hallo, heute ist es so spaet: " + timeService.GetTime());
        }
    }
}
