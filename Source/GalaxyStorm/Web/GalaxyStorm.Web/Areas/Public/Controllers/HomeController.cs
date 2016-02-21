namespace GalaxyStorm.Web.Areas.Public.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        // GET: Public/Home
        public ActionResult Index()
        {
            if (HttpContext.Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Preview", new { Area = "Planet"});
            }

            return View();
        }
    }
}