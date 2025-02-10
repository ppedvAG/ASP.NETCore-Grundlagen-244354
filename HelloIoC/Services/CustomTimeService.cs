namespace HelloIoC.Services
{
    public class CustomTimeService : ITimeService
    {
        private readonly string message;

        public CustomTimeService(string message)
        {
            this.message = message;
        }

        public string GetTime()
        {
            return message + "\t" + DateTime.Now.ToString();
        }
    }
}
