namespace GalaxyStorm.Web.Areas.Planet.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;
    using Logic.Core;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Fleet;

    public class FleetController : UsersController
    {
        private readonly IBuildingsService buildingsService;
        private readonly IFleetService fleetService;
        private readonly IPlayerService playerService;
        private readonly ITechnologiesService techService;
        private readonly ILogicProvider logic;

        public FleetController(IPlayerService playerService, IBuildingsService buildingsService, IFleetService fleetService, ITechnologiesService techService, ILogicProvider logic)
        {
            this.playerService = playerService;
            this.buildingsService = buildingsService;
            this.fleetService = fleetService;
            this.techService = techService;
            this.logic = logic;
        }

        // GET: Planet/Fleet
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var barracksLevel = this.buildingsService.GetPlayerBuildings(userId).BarracksLevel;
            var fleet = this.fleetService.GetPlayerFleet(userId);
            var cheaperFleet = this.techService.GetPlayerTechnologies(userId).CheaperFleetLevel;

            var cheaperFleetModifier = this.logic.Technologies.CheaperFleet.Modifier[cheaperFleet];

            var vM = new FleetViewModel(barracksLevel, fleet)
            {
                Scout = new UnitViewModel(fleet.ScoutsQuantity, fleet.DispatchedScouts, this.logic.Ships.Scout, cheaperFleetModifier),
                Carrier = new UnitViewModel(fleet.CarriersQuantity, fleet.DispatchedCarriers, this.logic.Ships.Carrier, cheaperFleetModifier),
                Fighter = new UnitViewModel(fleet.FighterQuantity, fleet.DispatchedFighters, this.logic.Ships.Fighter, cheaperFleetModifier),
                Interceptor = new UnitViewModel(fleet.InterceptorQuantity, fleet.DispatchedInterceptors, this.logic.Ships.Interceptor, cheaperFleetModifier),
                Bomber = new UnitViewModel(fleet.BomberQuantity, fleet.DispatchedBombers, this.logic.Ships.Bomber, cheaperFleetModifier),
                Juggernaut = new UnitViewModel(fleet.JuggernautQuantity, fleet.DispatchedJuggernauts, this.logic.Ships.Juggernaut, cheaperFleetModifier)
            };

            var reqRes = this.playerService.GetPlayerResources(userId);
            ViewBag.Energy = reqRes.Energy;
            ViewBag.Crystal = reqRes.Crystal;
            ViewBag.Metal = reqRes.Metal;

            return View(vM);
        }
    }
}