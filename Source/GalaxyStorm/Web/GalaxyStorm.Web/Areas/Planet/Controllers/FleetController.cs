namespace GalaxyStorm.Web.Areas.Planet.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;

    public class FleetController : UsersController
    {
        // GET: Planet/Fleet
        public ActionResult Index()
        {
            return View();
        }
    }
}