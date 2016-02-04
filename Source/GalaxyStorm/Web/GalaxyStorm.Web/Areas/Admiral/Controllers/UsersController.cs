namespace GalaxyStorm.Web.Areas.Admiral.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;

    public class UsersController : AdminController
    {
        // GET: AdmiralsQuarters/Users
        public ActionResult Index()
        {
            return View();
        }
    }
}