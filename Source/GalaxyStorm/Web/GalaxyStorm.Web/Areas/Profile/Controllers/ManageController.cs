namespace GalaxyStorm.Web.Areas.Profile.Controllers
{
    using System.Web.Mvc;
    using Services.Data.Contracts;

    public class ManageController : Controller
    {
        private readonly IReportsService reportsService;
        private readonly IPlayerService playerService;

        public ManageController(IReportsService reportsService, IPlayerService playerService)
        {
            this.reportsService = reportsService;
            this.playerService = playerService;
        }

        // GET: Profile/Manage
        public ActionResult Index()
        {
            return View();
        }
    }
}