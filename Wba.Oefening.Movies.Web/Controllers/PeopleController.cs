using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Movies.Core;
using Wba.Oefening.Movies.Web.Models;
using Wba.Oefening.Movies.Web.ViewModels;

namespace Wba.Oefening.Movies.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ActorRepository _actorRepository = new();
        private readonly DirectorRepository _directorRepository = new();
        private readonly MovieRepository _moviesRepository = new();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowDirectors()
        {
            ViewBag.PageTitle = "Our directors";
            var peopleShowDirectorsViewModel = new PeopleShowPersonsViewModel
            { 
                Persons = _directorRepository
                .GetDirectors()
                .Select(d => new BasePersonViewModel 
                {
                    Id = d?.Id,
                    Name = $"{d.FirstName} {d.SurName}"
                })
            };
            return View(peopleShowDirectorsViewModel);
        }
        public IActionResult ShowDirectorMovies(long id)
        {
            //check for director
            var director = _directorRepository
                    .GetDirectors()
                    .FirstOrDefault(d => d.Id == id);
            if(director == null)
            {
                return View("Error", new ErrorViewModel());
            }
            //get the movies of the director
            var peopleShowDirectorMoviesViewModel = new PeopleShowPersonMoviesViewModel 
            {
                Name = $"{director.FirstName} {director.SurName}",
                Movies = _moviesRepository.GetMovies()
                .Where(m => m.Directors.Any(d => d.Id == id))
                .Select(m => new MoviesShowMovieViewModel 
                {
                    Id = m?.Id,
                    Title = m?.Title,
                    Image = m?.Image
                })
            };
            return View(peopleShowDirectorMoviesViewModel);
        }
        public IActionResult ShowActors()
        {
            ViewBag.PageTitle = "Our directors";
            var peopleShowActorsViewModel = new PeopleShowPersonsViewModel
            {
                Persons = _actorRepository
                .GetActors()
                .Select(d => new BasePersonViewModel
                {
                    Id = d?.Id,
                    Name = $"{d.FirstName} {d.SurName}"
                })
            };
            return View(peopleShowActorsViewModel);
        }
        public IActionResult ShowActorMovies(long id)
        {
            //check for actor
            var actor = _actorRepository
                    .GetActors()
                    .FirstOrDefault(d => d.Id == id);
            if (actor == null)
            {
                return View("Error", new ErrorViewModel());
            }
            //get the movies of the director
            var peopleShowActorMoviesViewModel = new PeopleShowPersonMoviesViewModel
            {
                Name = $"{actor.FirstName} {actor.SurName}",
                Movies = _moviesRepository.GetMovies()
                .Where(m => m.Actors.Any(d => d.Id == id))
                .Select(m => new MoviesShowMovieViewModel
                {
                    Id = m?.Id,
                    Title = m?.Title,
                    Image = m?.Image
                })
            };
            ViewBag.PageTitle = "Movies of";
            return View(peopleShowActorMoviesViewModel);
        }
    }
}
