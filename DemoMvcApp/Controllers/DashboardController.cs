using BusinessModel.Contracts;
using DemoMvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IOrderServiceAsync orderService;

        public DashboardController(IOrderServiceAsync orderService)
        {
            this.orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            string userName = "John Doe";
            var model = new DashboardViewModel
            {
                UserName = userName,
                CurrentOrder = await orderService.CurrentOrder(userName)
            };

            return View(model);
        }
    }
}
