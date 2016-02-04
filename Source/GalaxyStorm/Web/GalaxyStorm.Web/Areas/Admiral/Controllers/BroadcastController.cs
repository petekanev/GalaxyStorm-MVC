namespace GalaxyStorm.Web.Areas.Admiral.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;

    public class BroadcastController : AdminController
    {
        // GET: AdmiralsQuarters/Broadcast
        public ActionResult Index()
        {
            return View();
        }
    }
}