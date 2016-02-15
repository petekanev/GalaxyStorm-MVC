namespace GalaxyStorm.Web.Areas.Public.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;

    public class InfoController : Controller
    {
        // GET: Public/Info
        public ActionResult Index()
        {
            return View();
        }
    }
}