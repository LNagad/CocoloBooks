using System.Web;
using System.Web.Optimization;

namespace CapaPresentacionAdmin
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //el que tenemos que agregar -- cambiamos el Bundlescript por Bundle

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                "~/Scripts/scripts.js",
                "~/Scripts/bootstrap.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/complementos").Include(
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/jquery.dataTables.responsive.js",
                        "~/Scripts/fontawesome/all.min.js",
                        "~/Scripts/scripts.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Site.css",
                "~/Content/DataTables/css/jquery.dataTables.css",
                "~/Content/DataTables/css/jquery.responsive.dataTables.css"));

            //site 2
            bundles.Add(new StyleBundle("~/Content/css2").Include(
                "~/Content/Site2.css"));

            bundles.Add(new ScriptBundle("~/bundles/complementos2").Include(
                       "~/Scripts/fontawesome/all.min.js"));

            bundles.Add(new Bundle("~/bundles/bootstrap2").Include(
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/bootstrap.bundle.js"));
        }
    }
}
