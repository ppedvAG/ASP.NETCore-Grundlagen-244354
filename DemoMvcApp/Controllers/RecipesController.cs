using BusinessModel.Contracts;
using BusinessModel.Models;
using DemoMvcApp.Mappers;
using DemoMvcApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeService recipeService;
        private readonly ILogger<RecipesController> logger;

        public RecipesController(IRecipeService recipeService, ILogger<RecipesController> logger)
        {
            this.recipeService = recipeService;
            this.logger = logger;
        }

        // GET: RecipesController
        public ActionResult<IEnumerable<RecipesViewModel>> Index()
        {
            var model = recipeService.GetAll().Select(e => e.ToViewModel());
            return View(model.Take(10));
        }

        // GET: RecipesController/Details/5
        public ActionResult<RecipesViewModel> Details(int id)
        {
            var model = recipeService.GetById(id);
            return View(model?.ToViewModel());
        }

        // GET: RecipesController/Create
        public ActionResult Create()
        {
            return View(new CreateRecipesViewModel());
        }

        // POST: RecipesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRecipesViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    recipeService.Add(model.ToDomainModel());
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, ex.Message);
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage);
                ModelState.AddModelError(string.Empty, string.Join(Environment.NewLine, errors));
            }

            return View(model);
        }

        // GET: RecipesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecipesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecipesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
