namespace GalaxyStorm.Web.Areas.Admiral.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;

    public class SupplementsController : AdminController
    {
        // GET: AdmiralsQuarters/Supplements
        public ActionResult Index()
        {
            return View();
        }
    }
}