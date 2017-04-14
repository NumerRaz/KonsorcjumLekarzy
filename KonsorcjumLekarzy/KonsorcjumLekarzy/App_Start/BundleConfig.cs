using System.Web;
using System.Web.Optimization;

namespace KonsorcjumLekarzy
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            var angularBundleModules = new ScriptBundle("~/bundles/AngularModules")
                .Include("~/Angular/app.js")
                .Include("~/Angular/theme/theme.module.js")
                .Include("~/Angular/theme/theme.config.js")
                .Include("~/Angular/theme/theme.configProvider.js")
                .Include("~/Angular/theme/theme.constants.js")
                .Include("~/Angular/theme/theme.run.js")
                .Include("~/Angular/theme/theme.service.js")
                .Include("~/Angular/theme/components/components.module.js")
                .Include("~/Angular/theme/inputs/inputs.module.js")
                .IncludeDirectory("~/Angular/theme", "*.js", true)
                .Include("~/Angular/pages/pages.module.js")
                .Include("~/Angular/pages/dashboard/dashboard.module.js")
                .IncludeDirectory("~/Angular/pages", "*.js", true);



            bundles.Add(angularBundleModules);

            //        var angularBundlePagesApp = new ScriptBundle("~/bundles/AngularPagesApp")
            //            .Include("~/Angular/pages/pages.module.js")
            //            .Include("~/Angular/pages/dashboard/dashboard.module.js");
            //        bundles.Add(angularBundlePagesApp);

            //        var angularBundleThemeComponentApp = new ScriptBundle("~/bundles/AngularThemesComponentApp")
            //            .Include("~/Angular/theme/components/component.module.js");
            //        bundles.Add(angularBundleThemeComponentApp);

            //        var angularBundleThemeComponent = new ScriptBundle("~/bundles/AngularThemesComponent")
            //.IncludeDirectory("~/Angular/theme/components", "*.js", true);
            //        bundles.Add(angularBundleThemeComponent);

            //        var angularBundleTheme = new ScriptBundle("~/bundles/AngularThemes")
            //            .IncludeDirectory("~/Angular/theme", "*.js", true);
            //        bundles.Add(angularBundleTheme);



            //        var angularBundleApp = new ScriptBundle("~/bundles/AngularApp")
            //            .Include("~/Angular/app.js");
            //        bundles.Add(angularBundleApp);

            var scriptsBundle = new ScriptBundle("~/bundles/PluginScripts")
                .Include("~/Content/plugins/scripts/jquery.js")
                .Include("~/Content/plugins/scripts/jquery-ui.js")
                .Include("~/Content/plugins/scripts/jquery.easing.js")
                .Include("~/Content/plugins/scripts/jquery.easypiechart.js")
                .Include("~/Content/plugins/scripts/Chart.js")
                .Include("~/Content/plugins/scripts/amcharts.js")
                .Include("~/Content/plugins/scripts/responsive.min.js")
                .Include("~/Content/plugins/scripts/serial.js")
                .Include("~/Content/plugins/scripts/funnel.js")
                .Include("~/Content/plugins/scripts/pie.js")
                .Include("~/Content/plugins/scripts/gantt.js")
                .Include("~/Content/plugins/scripts/amstock.js")
                .Include("~/Content/plugins/scripts/ammap.js")
                .Include("~/Content/plugins/scripts/worldLow.js")
                .Include("~/Content/plugins/scripts/angular.js")
                .Include("~/Content/plugins/scripts/angular-route.js")
                .Include("~/Content/plugins/scripts/jquery.slimscroll.js")
                .Include("~/Content/plugins/scripts/angular-slimscroll.js")
                .Include("~/Content/plugins/scripts/smart-table.js")
                .Include("~/Content/plugins/scripts/angular-toastr.tpls.js")
                .Include("~/Content/plugins/scripts/angular-touch.js")
                .Include("~/Content/plugins/scripts/sortable.js")
                .Include("~/Content/plugins/scripts/dropdown.js")
                .Include("~/Content/plugins/scripts/bootstrap-select.js")
                .Include("~/Content/plugins/scripts/bootstrap-switch.js")
                .Include("~/Content/plugins/scripts/bootstrap-tagsinput.js")
                .Include("~/Content/plugins/scripts/moment.js")
                .Include("~/Content/plugins/scripts/fullcalendar.js")
                .Include("~/Content/plugins/scripts/leaflet-src.js")
                .Include("~/Content/plugins/scripts/angular-progress-button-styles.min.js")
                .Include("~/Content/plugins/scripts/angular-ui-router.js")
                .Include("~/Content/plugins/scripts/angular-chart.js")
                .Include("~/Content/plugins/scripts/chartist.min.js")
                .Include("~/Content/plugins/scripts/angular-chartist.js")
                .Include("~/Content/plugins/scripts/chartist.min.js")
                .Include("~/Content/plugins/scripts/angular-chartist.js")
                .Include("~/Content/plugins/scripts/chartist.min.js")
                .Include("~/Content/plugins/scripts/angular-chartist.js")
                .Include("~/Content/plugins/scripts/eve.js")
                .Include("~/Content/plugins/scripts/raphael.min.js")
                .Include("~/Content/plugins/scripts/mocha.js")
                .Include("~/Content/plugins/scripts/morris.js")
                .Include("~/Content/plugins/scripts/angular-morris-chart.min.js")
                .Include("~/Content/plugins/scripts/ion.rangeSlider.js")
                .Include("~/Content/plugins/scripts/ui-bootstrap-tpls.js")
                .Include("~/Content/plugins/scripts/angular-animate.js")
                .Include("~/Content/plugins/scripts/rangy-core.js")
                .Include("~/Content/plugins/scripts/rangy-classapplier.js")
                .Include("~/Content/plugins/scripts/rangy-highlighter.js")
                .Include("~/Content/plugins/scripts/rangy-selectionsaverestore.js")
                .Include("~/Content/plugins/scripts/rangy-serializer.js")
                .Include("~/Content/plugins/scripts/rangy-textrange.js")
                .Include("~/Content/plugins/scripts/textAngular.js")
                .Include("~/Content/plugins/scripts/textAngular-sanitize.js")
                .Include("~/Content/plugins/scripts/textAngularSetup.js")
                .Include("~/Content/plugins/scripts/xeditable.js")
                .Include("~/Content/plugins/scripts/jstree.js")
                .Include("~/Content/plugins/scripts/ngJsTree.js")
                .Include("~/Content/plugins/scripts/select.js");
            bundles.Add(scriptsBundle);

            var styleBundle = new StyleBundle("~/bundles/PluginStyles")
                .IncludeDirectory("~/Content/plugins/styles/", "*.css", true);
            bundles.Add(styleBundle);

            BundleTable.EnableOptimizations = false;
        }
    }
}
