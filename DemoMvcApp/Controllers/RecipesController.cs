using BusinessModel.Contracts;
using BusinessModel.Models;
using DemoMvcApp.Mappers;
using DemoMvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeServiceAsync recipeService;
        private readonly ILogger<RecipesController> logger;

        public RecipesController(IRecipeServiceAsync recipeService, ILogger<RecipesController> logger)
        {
            this.recipeService = recipeService;
            this.logger = logger;
        }

        // GET: RecipesController
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 12)
        {
            var paginatedList = await recipeService.GetAll(pageNumber, pageSize);
            return View(paginatedList.Select(e => e.ToViewModel()));
        }

        // GET: RecipesController/Details/5
        public async Task<ActionResult<RecipesViewModel>> Details(int id)
        {
            var model = await recipeService.GetById(id);
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
        public async Task<ActionResult> Create(CreateRecipesViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.Image != null)
                    {
                        try
                        {
                            var fileName = model.Image.FileName;
                            using var stream = model.Image.OpenReadStream();
                            await recipeService.AddWithImage(model.ToDomainModel(), stream, fileName);
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex.Message);
                            ModelState.AddModelError(nameof(CreateRecipesViewModel.Image), ex.Message);
                        }
                    } 
                    else
                    {
                        await recipeService.Add(model.ToDomainModel());
                    }

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
