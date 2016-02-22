namespace GalaxyStorm.Web.Areas.Profile.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Data.Models.PlayerObjects;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Common;

    public class PreviewController : Controller
    {
        private readonly IReportsService reportsService;
        private readonly IPlayerService playerService;

        public PreviewController(IReportsService reportsService, IPlayerService playerService)
        {
            this.reportsService = reportsService;
            this.playerService = playerService;
        }

        // GET: Profile/Manage
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var player = this.playerService.GetPlayerInformation(userId);

            var vM = Mapper.Map<PlayerObject, SimplePlayerViewModel>(player);

            return View(vM);
        }
    }
}