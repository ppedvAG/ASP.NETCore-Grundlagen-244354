﻿using BusinessModel.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderServiceAsync orderService;
        private readonly IRecipeServiceAsync recipeService;

        public string UserName => User.Identity.Name ?? "Guest";

        public OrdersController(IOrderServiceAsync orderService, IRecipeServiceAsync recipeService)
        {
            this.orderService = orderService;
            this.recipeService = recipeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Order(int recipeId, int quantity)
        {
            var recipe = await recipeService.GetById(recipeId);
            await orderService.UpdateOrder(UserName, recipe, quantity);

            return RedirectToAction("Index", "Recipes");
        }

        [HttpPost]
        public async Task<IActionResult> Done(IFormCollection form)
        {
            await orderService.FinishOrder(UserName);

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
