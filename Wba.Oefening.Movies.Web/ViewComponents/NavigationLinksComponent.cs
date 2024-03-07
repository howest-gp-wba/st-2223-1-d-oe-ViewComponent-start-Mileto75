using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Movies.Web.Services;
using Wba.Oefening.Movies.Web.ViewModels;

namespace Wba.Oefening.Movies.Web.ViewComponents
{
    [ViewComponent(Name = "NavigationLinks")]
    public class NavigationLinksComponent : ViewComponent
    {
        private readonly LinkBuilder _linkBuilder;
        public NavigationLinksComponent()
        {
            _linkBuilder = new LinkBuilder();
        }
        public IViewComponentResult Invoke()
        {
            var navigationLinksComponentViewModel = new NavigationLinksComponentViewModel
            {
                ActionLinks = _linkBuilder.GetActionLinks(),
            };
            return View(navigationLinksComponentViewModel);
        }

    }
}
