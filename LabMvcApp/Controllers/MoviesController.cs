using LabMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Contracts;
using MovieStore.Models;

namespace LabMvcApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: MoviesController
        public ActionResult Index()
        {
            var result = _movieService.GetMovies();
            return View(result);
        }

        // GET: MoviesController/Details/5
        public ActionResult Details(int id)
        {
            var result = _movieService.GetById(id);
            return View(result);
        }

        // GET: MoviesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateMovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var movie = new Movie
                {
                    Id = DateTime.Now.Ticks,
                    Title = model.Title,
                    Description = model.Description,
                    Genre = model.Genre,
                    IMDBRating = model.IMDBRating,
                    Price = model.Price
                };

                _movieService.AddMovie(movie);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: MoviesController/Edit/5
        public ActionResult Edit(int id)
        {
            var movie = _movieService.GetById(id);
            return View(movie);
        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movie model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _movieService.UpdateMovie(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to update movie.");
            }
            return View();
        }

        // GET: MoviesController/Delete/5
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var movie = _movieService.GetById(id);
                if (movie != null)
                {
                    _movieService.RemoveMovie(movie);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to delete movie");
            }
            return View();
        }
    }
}
