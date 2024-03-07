using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Movies.Core;
using Wba.Oefening.Movies.Web.Models;
using Wba.Oefening.Movies.Web.ViewModels;

namespace Wba.Oefening.Movies.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieRepository _movieRepository = new();
        public IActionResult Index()
        {
            var moviesIndexViewModel = new MoviesIndexViewModel 
            {
                Movies = _movieRepository
                .GetMovies()
                .Select(m => new MoviesShowMovieViewModel 
                {
                    Id = m?.Id,
                    Title = m?.Title,
                    Image = m?.Image
                })
            };
            ViewBag.PageTitle = "Our movies";
            return View(moviesIndexViewModel);
        }
        public IActionResult ShowMovie(Guid movieId)
        {
            var movie = _movieRepository.GetMovies()
                .FirstOrDefault(m => m.Id == movieId);
            if(movie == null)
            {
                ErrorViewModel errorViewModel = new();
                return View("Error", errorViewModel);
            }
            var moviesShowMovieViewModel = new MoviesShowMovieViewModel 
            { 
                Id = movieId,
                Title = movie?.Title,
                Image = movie?.Image,
                Genre = movie?.Genre.Name,
                Directors = movie.Directors.Select(d =>
                new BasePersonViewModel
                {
                    Id = d?.Id,
                    Name = $"{d.FirstName} {d.SurName}"
                }),
                Actors = movie.Actors.Select(a =>
                new BasePersonViewModel
                {
                    Id = a?.Id,
                    Name = $"{a.FirstName} {a.SurName}"
                })
            };
            return View(moviesShowMovieViewModel);
        }
    }
}
