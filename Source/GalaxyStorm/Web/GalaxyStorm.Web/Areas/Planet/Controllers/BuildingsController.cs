namespace GalaxyStorm.Web.Areas.Planet.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;

    public class BuildingsController : UsersController
    {
        // GET: Planet/Buildings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Headquarters()
        {
            ViewBag.Title = "Headquarters";

            return View("Building");
        }

        public ActionResult ResearchCentre()
        {
            ViewBag.Title = "Research Centre";

            return View("Building");
        }

        public ActionResult Barracks()
        {
            ViewBag.Title = "Barracks";

            return View("Building");
        }

        public ActionResult SolarCollector()
        {
            ViewBag.Title = "Solar Collector";

            return View("Building");
        }

        public ActionResult CrystalExtractor()
        {
            ViewBag.Title = "Crystal Extractor";

            return View("Building");
        }

        public ActionResult MetalScrapper()
        {
            ViewBag.Title = "Metal Scrapper";

            return View("Building");
        }
    }
}