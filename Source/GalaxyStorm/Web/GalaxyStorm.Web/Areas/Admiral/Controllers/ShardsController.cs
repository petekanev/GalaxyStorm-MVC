namespace GalaxyStorm.Web.Areas.Admiral.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;

    public class ShardsController : AdminController
    {
        // GET: AdmiralsQuarters/Shards
        public ActionResult Index()
        {
            return View();
        }
    }
}