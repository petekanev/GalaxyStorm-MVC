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
                        "~/Scripts/jquery-2.2.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/theme/bootstrap-theme-dark.min.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/public").Include(
                    "~/Content/public/style.css",
                    "~/Content/public/color.css",
                    "~/Content/public/title-size.css",
                    "~/Content/public/custom.css"
                    ));

            bundles.Add(new StyleBundle("~/Content/common").Include(
                    "~/Content/public/style.css",
                    "~/Content/public/color.css",
                    "~/Content/public/title-size.css"
                    ));

            bundles.Add(new StyleBundle("~/Content/hex").Include(
                "~/Content/hex/hexagons.css",
                "~/Content/hex/custom-hex.css"));

            bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
                "~/Content/jqueryui/jquery-ui.min.css",
                "~/Content/jqueryui/jquery-ui.structure.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/public").Include(
                    "~/Scripts/common/vendor/vendor.js",
                    "~/Scripts/public/variables.js",
                    "~/Scripts/common/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                    "~/Scripts/common/vendor/vendor.js",
                    "~/Scripts/common/variables.js",
                    "~/Scripts/common/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jqueryui/jquery-ui.min.js"));
        }
    }
}
