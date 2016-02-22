﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using GalaxyStorm.Data.Models;

namespace GalaxyStorm.Web.Areas.Admiral.Controllers
{
    public class ShardsController : Controller
    {
        private GalaxyStormDbContext db = new GalaxyStormDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Shards_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Shard> shards = db.Shards;
            DataSourceResult result = shards.ToDataSourceResult(request, shard => new {
                Id = shard.Id,
                Title = shard.Title,
                ShardSize = shard.ShardSize,
                BuildSpeed = shard.BuildSpeed,
                IsLocked = shard.IsLocked
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Shards_Update([DataSourceRequest]DataSourceRequest request, Shard shard)
        {
            if (ModelState.IsValid)
            {
                var entity = new Shard
                {
                    Id = shard.Id,
                    Title = shard.Title,
                    ShardSize = shard.ShardSize,
                    BuildSpeed = shard.BuildSpeed,
                    IsLocked = shard.IsLocked
                };

                db.Shards.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { shard }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
