namespace GalaxyStorm.Web.Areas.Planet.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Common;

    public class PreviewController : Controller
    {
        private readonly IPlayerService playerService;

        public PreviewController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        // GET: Planet/Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Resources()
        {
            var userId = User.Identity.GetUserId();

            var res = this.playerService.GetPlayerResources(userId);

            var resVM = new ResourcesViewModel { Energy = res.Energy, Crystal = res.Crystal, Metal = res.Metal};

            return View(resVM);
        }
    }
}