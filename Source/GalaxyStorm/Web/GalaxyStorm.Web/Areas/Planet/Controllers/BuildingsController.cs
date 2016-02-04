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
    }
}