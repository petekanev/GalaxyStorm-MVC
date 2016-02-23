namespace GalaxyStorm.Web.Areas.Admiral.Controllers
{
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using ViewModels.Supplements;

    public class SupplementsController : Controller
    {
        private readonly IPlayerService playerService;

        public SupplementsController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var players = this.playerService.GetPlayers().ProjectTo<SupplementsViewModel>();

            var result = players.ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, SupplementsViewModel vM)
        {
            if (ModelState.IsValid)
            {
                this.playerService.UpdateResources(vM.Id, vM.Energy, vM.Crystal, vM.Metal);
            }

            return Json(new[] { vM }.ToDataSourceResult(request, ModelState));
        }
    }
}
