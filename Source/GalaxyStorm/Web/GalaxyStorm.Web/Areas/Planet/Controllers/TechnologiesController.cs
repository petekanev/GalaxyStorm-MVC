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

            return View();
        }

        public ActionResult LargerFleet()
        {
            ViewBag.Title = "Larger Fleet";

            return View();
        }

        public ActionResult CheaperFleet()
        {
            ViewBag.Title = "Cheaper Fleet";

            return View();
        }

        public ActionResult MoreResources()
        {
            ViewBag.Title = "Bountiful Mines";

            return View();
        }

        public ActionResult FasterConstruction()
        {
            ViewBag.Title = "Nimble Workers";

            return View();
        }
    }
}