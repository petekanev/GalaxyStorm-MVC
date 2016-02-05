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
            return View();
        }

        public ActionResult ResearchCentre()
        {
            return View();
        }

        public ActionResult Barracks()
        {
            return View();
        }

        public ActionResult SolarCollector()
        {
            return View();
        }

        public ActionResult CrystalExtractor()
        {
            return View();
        }

        public ActionResult MetalScrapper()
        {
            return View();
        }
    }
}