namespace GalaxyStorm.Web.Areas.Public.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        // GET: Public/Error
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }

        public ActionResult BadRequest()
        {
            Response.StatusCode = 400;
            return View();
        }
    }
}