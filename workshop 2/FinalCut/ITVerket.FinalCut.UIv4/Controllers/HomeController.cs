using System.Web.Mvc;
using ITVerket.FinalCut.Services;
using ITVerket.FinalCut.Services.Interfaces;
using ITVerket.FinalCut.UIv4.Models;

namespace ITVerket.FinalCut.UIv4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        public HomeController()
        {
            _movieService = new MovieService();
        }

        public ActionResult Index()
        {
            var model = new FrontPageViewModel
                            {
                                FeaturedMovies = _movieService.GetFeaturedMovies()
                            };

            return View(model);
        }

    }
}
