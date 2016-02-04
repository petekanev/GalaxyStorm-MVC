namespace GalaxyStorm.Web.Infrastructure
{
    using System.Web.Mvc;

    [Authorize(Roles = "Admiral")]
    public abstract class AdminController : Controller
    {
    }
}