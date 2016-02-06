namespace GalaxyStorm.Web.Areas.Planet.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;

    public class TechnologiesController : UsersController
    {
        // GET: Planet/Technologies
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ArmoredFleet()
        {
            ViewBag.Title = "Armored Fleet";

            return View("Technology");
        }

        public ActionResult LargerFleet()
        {
            ViewBag.Title = "Larger Fleet";

            return View("Technology");
        }

        public ActionResult CheaperFleet()
        {
            ViewBag.Title = "Cheaper Fleet";

            return View("Technology");
        }

        public ActionResult MoreResources()
        {
            ViewBag.Title = "Bountiful Mines";

            return View("Technology");
        }

        public ActionResult FasterConstruction()
        {
            ViewBag.Title = "Nimble Workers";

            return View("Technology");
        }
    }
}