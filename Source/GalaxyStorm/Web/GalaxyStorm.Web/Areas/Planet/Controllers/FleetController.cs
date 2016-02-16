namespace GalaxyStorm.Web.Areas.Planet.Controllers
{
    using System.Web.Mvc;
    using Hangfire;
    using Infrastructure;
    using Logic.Core;
    using Microsoft.AspNet.Identity;
    using Services.Data;
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

        public ActionResult Scout()
        {
            var userId = User.Identity.GetUserId();

            var modifier = this.GetCheaperFleetModifier(userId);

            var vM = new UnitViewModel(this.logic.Ships.Scout, modifier);

            return View(vM);
        }

        public ActionResult Carrier()
        {
            var userId = User.Identity.GetUserId();

            var modifier = this.GetCheaperFleetModifier(userId);

            var vM = new UnitViewModel(this.logic.Ships.Carrier, modifier);

            return View(vM);
        }

        public ActionResult Fighter()
        {
            var userId = User.Identity.GetUserId();

            var modifier = this.GetCheaperFleetModifier(userId);

            var vM = new UnitViewModel(this.logic.Ships.Fighter, modifier);

            return View(vM);
        }

        public ActionResult Bomber()
        {
            var userId = User.Identity.GetUserId();

            var modifier = this.GetCheaperFleetModifier(userId);

            var vM = new UnitViewModel(this.logic.Ships.Bomber, modifier);

            return View(vM);
        }

        public ActionResult Interceptor()
        {
            var userId = User.Identity.GetUserId();

            var modifier = this.GetCheaperFleetModifier(userId);

            var vM = new UnitViewModel(this.logic.Ships.Interceptor, modifier);

            return View(vM);
        }

        public ActionResult Juggernaut()
        {
            var userId = User.Identity.GetUserId();

            var modifier = this.GetCheaperFleetModifier(userId);

            var vM = new UnitViewModel(this.logic.Ships.Juggernaut, modifier);

            return View(vM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecruitScouts(int amount)
        {
            var userId = User.Identity.GetUserId();

            var timespan = this.fleetService.ScheduleRecruitScout(userId, amount);

            if (timespan != null)
            {
                BackgroundJob.Schedule<FleetService>(x => x.CompleteRecruiting(userId), timespan.Value);
            }
            else
            {
                this.SetErrorMessage();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecruitFighters(int amount)
        {
            var userId = User.Identity.GetUserId();

            var timespan = this.fleetService.ScheduleRecruitFighter(userId, amount);

            if (timespan != null)
            {
                BackgroundJob.Schedule<FleetService>(x => x.CompleteRecruiting(userId), timespan.Value);
            }
            else
            {
                this.SetErrorMessage();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecruitCarriers(int amount)
        {
            var userId = User.Identity.GetUserId();

            var timespan = this.fleetService.ScheduleRecruitCarrier(userId, amount);

            if (timespan != null)
            {
                BackgroundJob.Schedule<FleetService>(x => x.CompleteRecruiting(userId), timespan.Value);
            }
            else
            {
                this.SetErrorMessage();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecruitBombers(int amount)
        {
            var userId = User.Identity.GetUserId();

            var timespan = this.fleetService.ScheduleRecruitBomber(userId, amount);

            if (timespan != null)
            {
                BackgroundJob.Schedule<FleetService>(x => x.CompleteRecruiting(userId), timespan.Value);
            }
            else
            {
                this.SetErrorMessage();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecruitInterceptors(int amount)
        {
            var userId = User.Identity.GetUserId();

            var timespan = this.fleetService.ScheduleRecruitInterceptor(userId, amount);

            if (timespan != null)
            {
                BackgroundJob.Schedule<FleetService>(x => x.CompleteRecruiting(userId), timespan.Value);
            }
            else
            {
                this.SetErrorMessage();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecruitJuggernauts(int amount)
        {
            var userId = User.Identity.GetUserId();

            var timespan = this.fleetService.ScheduleRecruitJuggernaut(userId, amount);

            if (timespan != null)
            {
                BackgroundJob.Schedule<FleetService>(x => x.CompleteRecruiting(userId), timespan.Value);
            }
            else
            {
                this.SetErrorMessage();
            }

            return RedirectToAction("Index");
        }

        protected override void SetErrorMessage()
        {
            TempData["Error"] =
                "You cannot recruit that many ships at the moment. You don't meet the requirements, or another batch of ships is being recruited!";
        }

        private double GetCheaperFleetModifier(string userId)
        {
            var cheaperFleet = this.techService.GetPlayerTechnologies(userId).CheaperFleetLevel;
            var cheaperFleetModifier = this.logic.Technologies.CheaperFleet.Modifier[cheaperFleet];

            return cheaperFleetModifier;
        }
    }
}