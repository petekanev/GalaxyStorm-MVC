namespace GalaxyStorm.Web.Areas.Profile.Controllers
{
    using System.Web.Mvc;

    public class ReportsController : Controller
    {
        // GET: Profile/Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return null;
        }
    }
}