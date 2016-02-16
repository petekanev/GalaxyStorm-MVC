namespace GalaxyStorm.Web.Areas.Shard.Controllers
{
    using System.Web.Mvc;

    public class PlanetController : Controller
    {
        // GET: Shard/Planet
        public ActionResult Index(string shard, string planet)
        {
            ViewBag.Title = planet;

            return View();
        }
    }
}