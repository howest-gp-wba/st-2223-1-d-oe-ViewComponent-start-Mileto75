using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Movies.Web.ViewModels;

namespace Wba.Oefening.Movies.Web.ViewComponents
{
    [ViewComponent(Name = "MenuComponent")]
    public class MenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            MenuComponentViewModel menuComponentViewModel = new ();
            menuComponentViewModel.Links = new List<LinkModel> 
            {
                new LinkModel
                {
                    Controller = "Movies",
                    Action = "Index",
                    Text = "Movies"
                },new LinkModel
                {
                    Controller = "People",
                    Action = "ShowDirectors",
                    Text = "Directors"
                },
                new LinkModel
                {
                    Controller = "People",
                    Action = "ShowActors",
                    Text = "Actors"
                },
            };
            
            if(menuComponentViewModel.Links.Any(l => 
            (l.Controller == HttpContext.GetRouteValue("Controller").ToString()
            &&
            l.Action == HttpContext.GetRouteValue("Actopn").ToString()
            )))
            {

            }
            return View(menuComponentViewModel);
        }
    }
}
