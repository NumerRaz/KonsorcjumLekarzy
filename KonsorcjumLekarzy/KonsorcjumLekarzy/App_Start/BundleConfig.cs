using System.Web;
using System.Web.Optimization;

namespace KonsorcjumLekarzy
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var initScript = new ScriptBundle("~/bundles/initScript")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.validate*")
                .Include("~/Scripts/modernizr-*")
                .Include("~/Scripts/bootstrap.js",
                    "~/Scripts/respond.js")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angularComponentRoute.js");
            
            var initStyle = new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css",
                      "~/Content/sb-admin.css",
                      "~/Content/site.css");

            var angular = new ScriptBundle("~/angular")
                .Include("~/Angular/app.js")
                .Include("~/Angular/appComponent/appComponent.js")
                .Include("~/Angular/navbarComponent/navbarComponent.js")
                .Include("~/Angular/singlePanelComponent/singlePanelComponent.js");

            bundles.Add(initScript);
            bundles.Add(initStyle);
            bundles.Add(angular);
        }
    }
}
