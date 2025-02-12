using BusinessModel.Models;

namespace DemoMvcApp.Models
{
    public class DashboardViewModel
    {
        public string UserName { get; set; }

        public Order? CurrentOrder { get; set; }
    }
}
