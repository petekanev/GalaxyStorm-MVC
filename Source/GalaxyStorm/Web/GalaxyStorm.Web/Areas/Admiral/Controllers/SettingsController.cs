namespace GalaxyStorm.Web.Areas.Admiral.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;

    public class SettingsController : AdminController
    {
        // GET: AdmiralsQuarters/Settings
        public ActionResult Index()
        {
            return View();
        }
    }
}