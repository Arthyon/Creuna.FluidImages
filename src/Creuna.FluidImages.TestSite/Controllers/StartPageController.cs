using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Creuna.FluidImages.TestSite.Models.Pages;

namespace Creuna.FluidImages.TestSite.Controllers
{
    public class StartPageController : PageController<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            return View(currentPage);
        }
    }
}