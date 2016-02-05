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
            return null;
        }

        public ActionResult ResearchCentre()
        {
            return null;
        }

        public ActionResult Barracks()
        {
            return null;
        }

        public ActionResult SolarCollector()
        {
            return null;
        }

        public ActionResult CrystalExtractor()
        {
            return null;
        }

        public ActionResult MetalScrapper()
        {
            return null;
        }
    }
}