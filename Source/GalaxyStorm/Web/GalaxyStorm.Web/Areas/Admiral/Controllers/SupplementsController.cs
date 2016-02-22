namespace GalaxyStorm.Web.Areas.Admiral.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Data;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using ViewModels.Shards;

    public class SupplementsController : Controller
    {
        private GalaxyStormDbContext db = new GalaxyStormDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<ShardViewModel> shardviewmodels = db.ShardViewModels;
            DataSourceResult result = shardviewmodels.ToDataSourceResult(request, shardViewModel => new {
                Id = shardViewModel.Id,
                Title = shardViewModel.Title,
                IsLocked = shardViewModel.IsLocked,
                BuildSpeed = shardViewModel.BuildSpeed
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ShardViewModel shardViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new ShardViewModel
                {
                    Id = shardViewModel.Id,
                    Title = shardViewModel.Title,
                    IsLocked = shardViewModel.IsLocked,
                    BuildSpeed = shardViewModel.BuildSpeed
                };

                db.ShardViewModels.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { shardViewModel }.ToDataSourceResult(request, ModelState));
        }
    }
}
