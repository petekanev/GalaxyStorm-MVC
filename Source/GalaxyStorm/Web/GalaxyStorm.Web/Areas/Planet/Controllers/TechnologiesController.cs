namespace GalaxyStorm.Web.Areas.Planet.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;

    public class TechnologiesController : UsersController
    {
        // GET: Planet/Technologies
        public ActionResult Index()
        {
            return View();
        }
    }
}