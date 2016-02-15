namespace GalaxyStorm.Web.Areas.Shard.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Common;

    public class PreviewController : UsersController
    {
        private readonly IShardService shardService;

        public PreviewController(IShardService shardService)
        {
            this.shardService = shardService;
        }

        // GET: Shard/Preview
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var currentShard = this.shardService.GetShardByPlayerId(userId);

            var vM = Mapper.Map<PublicShardViewModel>(currentShard);

            return View(vM);
        }
    }
}