namespace HelloIoC.Services
{
    public class UniversalTimeService : ITimeService
    {
        public string GetTime()
        {
            return "UTC: " + DateTime.UtcNow.ToString();
        }
    }
}
