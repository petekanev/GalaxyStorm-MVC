namespace GalaxyStorm.Web.Areas.Public.Controllers
{
    using System.Web.Mvc;
    using Data;
    using Data.Models;
    using Data.Repositories;
    using Hangfire;
    using Logic.Core;
    using Microsoft.AspNet.Identity;
    using Services.Data;

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

        public ActionResult UpgradeHQ()
        {
            var service = new BuildingService(new Repository<ApplicationUser>(new GalaxyStormDbContext()), new LogicProvider());

            var userId = HttpContext.User.Identity.GetUserId();

            var buildTime = service.ScheduleBuildHeadQuarters(userId);

            if (buildTime != null)
            {
                BackgroundJob.Schedule<BuildingService>(x => x.CompleteBuilding(userId), buildTime.Value);
            }

            return Redirect("/Public/Index");
        }
    }
}