using Microsoft.CodeAnalysis.CSharp.Syntax;
using Wba.Oefening.Movies.Web.Models;

namespace Wba.Oefening.Movies.Web.Services
{
    public class LinkBuilder
    {
        private IEnumerable<ActionLink> ActionLinks;
        public LinkBuilder()
        {
            ActionLinks = new List<ActionLink>
            {
                new ActionLink{ Controller = "Movies",Action="Index",Name = "Movies"},
                new ActionLink{ Controller = "People",Action="ShowDirectors",Name = "Directors"},
                new ActionLink{ Controller = "People",Action="ShowActors",Name = "Actors"},
            };
        }
        public IEnumerable<ActionLink> GetActionLinks()
        {
            return ActionLinks;
        }
    }
}
