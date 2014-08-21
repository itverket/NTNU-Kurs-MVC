using System.Linq;
using System.Web.Mvc;
using ITVerket.FinalCut.Domain.Entities.Enum;
using ITVerket.FinalCut.Services;
using ITVerket.FinalCut.Services.Interfaces;
using ITVerket.FinalCut.UIv4.Models;

namespace ITVerket.FinalCut.UIv4.Controllers
{
    public class SearchController : Controller
    {
        private readonly IMovieService _movieService;

        public SearchController()
        {
            _movieService = new MovieService();
        }

        public ActionResult Index()
        {
            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult Index(SearchCriteria? searchCriteria, string searchText)
        {
            
            searchText = searchText.Trim();
            switch (searchCriteria)
            {
                case SearchCriteria.All:
                    return RedirectToAction("All", new { searchText });
                case SearchCriteria.Genre:
                    return RedirectToAction("Genre", new { searchText });
                case SearchCriteria.Title:
                    return RedirectToAction("Title", new { searchText });
                case SearchCriteria.Actor:
                    return RedirectToAction("Actor", new { searchText });
                default:
                    return new HttpNotFoundResult();
            }
        }

        public ActionResult All(string searchText)
        {
            var result = _movieService.SearchAll(searchText);
            var model = result.Select(movie => new MovieViewModel(movie));

            return View("Index",model);
        }

        public ActionResult Genre(string searchText)
        {
            var result = _movieService.SearchGenre(searchText);
            var model = result.Select(movie => new MovieViewModel(movie));

            return View("Index", model);
        }

        public ActionResult Title(string searchText)
        {
            var result = _movieService.SearchTitle(searchText);
            var model = result.Select(movie => new MovieViewModel(movie));

            return View("Index", model);
        }

        public ActionResult Actor(string searchText)
        {
            var result = _movieService.SearchActor(searchText);
            var model = result.Select(movie => new MovieViewModel(movie));

            return View("Index", model);
        }

    }
}
