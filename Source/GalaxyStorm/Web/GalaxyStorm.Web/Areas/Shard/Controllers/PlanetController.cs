namespace GalaxyStorm.Web.Areas.Shard.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Common;

    public class PlanetController : UsersController
    {
        private readonly IPlanetService planetService;

        public PlanetController(IPlanetService planetService)
        {
            this.planetService = planetService;
        }

        // GET: Shard/Planet
        public ActionResult Index(string shard, string planet)
        {
            var userId = User.Identity.GetUserId();

            var planetResult = planetService.GetPublicPlanet(userId, shard, planet);

            if (planetResult == null)
            {
                this.SetErrorMessage();
                return RedirectToAction("Index", "Preview", new { area = "Shard"});
            }

            var currentPlayerPlanet = planetService.GetPlayerPlanet(userId);

            ViewData["PlayerPlanet"] = currentPlayerPlanet.Title;

            var vM = Mapper.Map<Planet, PublicPlanetViewModel>(planetResult);

            return View(vM);
        }

        protected override void SetErrorMessage()
        {
            TempData["Error"] = "Could not find the planet you were looking for! Are you lost?";
        }
    }
}