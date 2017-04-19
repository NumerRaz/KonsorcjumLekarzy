using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Optimization;

namespace KonsorcjumLekarzy
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var angularBundleModules = new ScriptBundle("~/bundles/AngularModules")
                .IncludeDirectory("~/Angular", "*.js", true);

            angularBundleModules.Orderer = new AngularBundleOrderer();
            bundles.Add(angularBundleModules);
            
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

    enum AngularFileTypes
    {
        Module,
        Config,
        Routes,
        Init,
        Constants,
        Service,
        Controller,
        Directive,
        Component,
        Filter,
        Spec,
        Other
    }

    public class AngularBundleOrderer : IBundleOrderer
    {
        private Regex typeRegex = new Regex(@"(?:^|\.)([\w-]+)\.js$");
        private Regex underscoreRegex = new Regex(@"^_");

        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            var ordered = files
                .GroupBy(GetFileType)
                .Where(group => group.Key != (int)AngularFileTypes.Spec)
                .OrderBy(group => group.Key)
                .SelectMany(group => group);

            return ordered;
        }

        private int GetFileType(BundleFile file)
        {
            if (underscoreRegex.IsMatch(file.VirtualFile.Name))
            {
                return -1;
            }

            AngularFileTypes result;
            var parsedType = typeRegex.Match(file.VirtualFile.Name).Groups[1].Value;

            if (!Enum.TryParse(parsedType, true, out result) || !Enum.IsDefined(typeof(AngularFileTypes), result))
            {
                result = AngularFileTypes.Other;
            }

            return (int)result;
        }
}
}
