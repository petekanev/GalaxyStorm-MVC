using System.Web;
using System.Web.Optimization;

namespace GalaxyStorm.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        //"~/Scripts/jquery-2.1.4.min.js"));
                        "~/Scripts/jquery-2.2.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                //"~/Content/theme/theme_dark.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/public").Include(
                    "~/Content/public/style.css",
                    "~/Content/public/color.css",
                    "~/Content/public/title-size.css",
                    "~/Content/public/custom.css"
                //"~/Content/public/vendor.css"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/public").Include(
                    "~/Scripts/public/vendor/vendor.js",
                    "~/Scripts/public/variables.js",
                    "~/Scripts/public/main.js"));
        }
    }
}
