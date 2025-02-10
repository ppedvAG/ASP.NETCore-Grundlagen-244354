using DemoMvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                UserName = "Max Mustermann"
            };
            return View(model);
        }
    }
}
