namespace GalaxyStorm.Web.Infrastructure
{
    using System.Web.Mvc;
    using Services.Web.Contracts;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        protected virtual void SetErrorMessage()
        {
            TempData["Error"] =
                "The operation could not be completed!";
        }

        protected void SetErrorMessage(string message)
        {
            TempData["Error"] = message;
        }

        protected void SetSuccessMessage(string message)
        {
            TempData["Success"] = message;
        }

        protected void SetInfoMessage(string message)
        {
            TempData["Info"] = message;
        }
    }
}