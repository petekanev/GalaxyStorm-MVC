namespace GalaxyStorm.Web.Infrastructure
{
    using System.Web.Mvc;

    [Authorize]
    public abstract class UsersController : Controller
    {
        protected virtual void SetErrorMessage()
        {
            TempData["Error"] =
                "The operation could not be completed!";
        }
    }
}